using AutoMapper;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Database;
using MoveMe.WebAPI.ML;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveMe.WebAPI.Services
{
    public class RequestService : BaseCRUDService<Model.Request, RequestSearchRequest, RequestInsertRequest, RequestUpdateRequest, Request>, IRequestService
    {
        static MLContext mlContext = null;
        static ITransformer model = null;
        public RequestService(MoveMeContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IList<Model.Request> GetAll(RequestSearchRequest search = null)
        {
            var query = _context.Request.AsQueryable();

            if (search?.UserId.HasValue == true)
            {
                query = query.Where(a => a.ClientId == search.UserId);
            }

            if (search?.CountryId.HasValue == true)
            {
                query = query.Where(a => a.DeliveryAddressNavigation.CountryId == search.CountryId);
            }

            if (search?.MaximumRooms.HasValue == true)
            {
                query = query.Where(a => a.Rooms <= search.MaximumRooms);
            }

            if (search?.MinimumPrice.HasValue == true)
            {
                query = query.Where(a => a.Price >= search.MinimumPrice);
            }

            if (search?.StatusId.HasValue == true)
            {
                query = query.Where(a => a.StatusId == search.StatusId);
            }

            if (search?.ShowInactive == false)
            {
                query = query.Where(a => a.Inactive == false);
            }

            var list = query.ToList();

            return _mapper.Map<IList<Model.Request>>(list);
        }

        public List<Model.Request> Recommend(int id)
        {
            /*
             The recommendation system works in such a way that if User 1 sends an offer for a some request, 
            it is checked whether another user has sent an offer for that request. 
            If so, then other requests for which user 2 has sent offers are also recommended to user 1.
            This recommendation system only works for requests that are not accepted or finished (requests for
            which you can send offer).
             */
            if (mlContext == null)
            {
                mlContext = new MLContext();

                var allRequests = _context.Request.Where(a => a.Inactive == false && a.StatusId == (int)Model.EStatus.Pending).ToList();
                var data = new List<ProductEntry>();

                foreach (var request in allRequests)
                {
                    var allRequestOffers = _context.Offer.Where(a => a.RequestId == request.RequestId && (a.OfferStatusId == (int)Model.EOfferStatus.Active || a.OfferStatusId == (int)Model.EOfferStatus.Rejected)).ToList();
                    foreach (var offer in allRequestOffers)
                    {
                        var relatedOffers = _context.Offer.Where(a => a.UserId == offer.UserId && a.OfferId != offer.OfferId).ToList();
                        foreach (var relatedOffer in relatedOffers)
                        {
                            var offerRequest = _context.Request.Find(relatedOffer.RequestId);

                            if (offerRequest.StatusId == (int)Model.EStatus.Pending && offerRequest.Inactive == false)
                            {
                                var relatedRequest = _context.Request.Find(offer.RequestId);

                                if (relatedRequest.StatusId == (int)Model.EStatus.Pending && relatedRequest.Inactive == false)
                                {
                                    data.Add(new ProductEntry
                                    {
                                        ProductID = (uint)offer.RequestId,
                                        CoPurchaseProductID = (uint)relatedOffer.RequestId
                                    });
                                }
                            }
                        }
                    }
                }

                if (data.Count == 0)
                {
                    return new List<Model.Request>();
                }

                var traindata = mlContext.Data.LoadFromEnumerable(data);
                
                MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                options.LabelColumnName = "Label";
                options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                options.Alpha = 0.01;
                options.Lambda = 0.025;
                
                // For better results use the following parameters
                //options.K = 100;
                options.C = 0.00001;

                var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                model = est.Fit(traindata);

              
            }
            if (model == null)
            {
                return new List<Model.Request>();
            }
            var allItems = _context.Request.Where(x => x.RequestId != id).ToList();
            var predictionResult = new List<Tuple<Request, float>>();

            foreach (var request in allItems)
            {
                var predictionengine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionengine.Predict(
                new ProductEntry()
                {
                    ProductID = (uint)id,
                    CoPurchaseProductID = (uint)request.RequestId
                });

                predictionResult.Add(new Tuple<Request, float>(request, prediction.Score));
            }
            var finalResult = predictionResult.OrderByDescending(a => a.Item2).Where(a => a.Item1.StatusId == (int)Model.EStatus.Pending && a.Item1.Inactive == false).Select(a => a.Item1).Take(3).ToList();

            return _mapper.Map<List<Model.Request>>(finalResult);
        }
    }
}
