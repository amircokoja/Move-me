using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            if (mlContext == null)
            {
                mlContext = new MLContext();

                var allRequests = _context.Request.Where(a => a.Inactive == false && a.StatusId == (int)Model.EStatus.Pending).ToList();
                var data = new List<ProductEntry>();

                foreach (var request in allRequests)
                {
                    // get all offers for specific request
                    var allRequestOffers = _context.Offer.Where(a => a.RequestId == request.RequestId).ToList();
                    foreach (var offer in allRequestOffers)
                    {
                        // get related offers (offers that the same user made for other requests)
                        var relatedOffers = _context.Offer.Where(a => a.UserId == offer.UserId && a.OfferId != offer.OfferId);

                        foreach (var relatedOffer in relatedOffers)
                        {
                            data.Add(new ProductEntry
                            {
                                ProductID = (uint)offer.RequestId,
                                CoPurchaseProductID = (uint)relatedOffer.RequestId
                            });
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
            var finalResult = predictionResult.OrderByDescending(a => a.Item2).Select(a => a.Item1).Take(3).ToList();

            return _mapper.Map<List<Model.Request>>(finalResult);
        }
    }
}
