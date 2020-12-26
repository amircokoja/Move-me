using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using MoveMe.Model;
using MoveMe.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class RequestDetailsViewModel : BaseViewModel
    {
        #region Properties
        int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        int _userId;
        public int UserId
        {
            get { return _userId; }
            set { SetProperty(ref _userId, value); }
        }
        int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set { SetProperty(ref _clientId, value); }
        }
        int _supplierId;
        public int SupplierId
        {
            get { return _supplierId; }
            set { SetProperty(ref _supplierId, value); }
        }
        DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }
        double _price;
        public double Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }
        int _rooms;
        public int Rooms
        {
            get { return _rooms; }
            set { SetProperty(ref _rooms, value); }
        }
        int _totalWeightApprox;
        public int TotalWeightApprox
        {
            get { return _totalWeightApprox; }
            set { SetProperty(ref _totalWeightApprox, value); }
        }
        int _transportDistanceApprox;
        public int TransportDistanceApprox
        {
            get { return _transportDistanceApprox; }
            set { SetProperty(ref _transportDistanceApprox, value); }
        }
        string _additionalInformation = string.Empty;
        public string AdditionalInformation
        {
            get { return _additionalInformation; }
            set { SetProperty(ref _additionalInformation, value); }
        }
        string _country = string.Empty;
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }
        string _zipCode = string.Empty;
        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode, value); }
        }
        string _city = string.Empty;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }
        string _additional = string.Empty;
        public string Additional
        {
            get { return _additional; }
            set { SetProperty(ref _additional, value); }
        }
        string _street = string.Empty;
        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }
        int _statusId;
        public int StatusId
        {
            get { return _statusId; }
            set { SetProperty(ref _statusId, value); }
        }
        string _status = string.Empty;
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
        string _statusColor = Color.LightSalmon.ToHex();
        public string StatusColor
        {
            get { return _statusColor; }
            set { SetProperty(ref _statusColor, value); }
        }
        string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        bool _isClient;
        public bool IsClient
        {
            get { return _isClient; }
            set { SetProperty(ref _isClient, value); }
        }

        bool _isSupplier;
        public bool IsSupplier
        {
            get { return _isSupplier; }
            set { SetProperty(ref _isSupplier, value); }
        }
        bool _sendOfferVisible;
        public bool SendOfferVisible
        {
            get { return _sendOfferVisible; }
            set { SetProperty(ref _sendOfferVisible, value); }
        }
        bool _offerSendMessageVisible;
        public bool OfferSendMessageVisible
        {
            get { return _offerSendMessageVisible; }
            set { SetProperty(ref _offerSendMessageVisible, value); }
        }

        bool _offerRejected;
        public bool OfferRejected
        {
            get { return _offerRejected; }
            set { SetProperty(ref _offerRejected, value); }
        }

        bool _offerFinished;
        public bool OfferFinished
        {
            get { return _offerFinished; }
            set { SetProperty(ref _offerFinished, value); }
        }

        bool _offerAcceptedVisible;
        public bool OfferAcceptedVisible
        {
            get { return _offerAcceptedVisible; }
            set { SetProperty(ref _offerAcceptedVisible, value); }
        }
        bool _haveAcceptedOffer;
        public bool HaveAcceptedOffer
        {
            get { return _haveAcceptedOffer; }
            set { SetProperty(ref _haveAcceptedOffer, value); }
        }
        bool _haveFinishedOffer;
        public bool HaveFinishedOffer
        {
            get { return _haveFinishedOffer; }
            set { SetProperty(ref _haveFinishedOffer, value); }
        }
        bool _feedbackSent;
        public bool FeedbackSent
        {
            get { return _feedbackSent; }
            set { SetProperty(ref _feedbackSent, value); }
        }
        bool _showList;
        public bool ShowList
        {
            get { return _showList; }
            set { SetProperty(ref _showList, value); }
        }
        public int _offersHegiht = 0;
        public int OffersHeight
        {
            get { return _offersHegiht; }
            set { SetProperty(ref _offersHegiht, value); }
        }

        bool _showRecommendList;
        public bool RecommendShowList
        {
            get { return _showRecommendList; }
            set { SetProperty(ref _showRecommendList, value); }
        }
        public ObservableCollection<RequestDetailsOffers> OfferList { get; set; } = new ObservableCollection<RequestDetailsOffers>();
        public ObservableCollection<RequestModel> RecommendedRequests { get; set; } = new ObservableCollection<RequestModel>();
        public ObservableCollection<Model.RatingType> RatingTypeList { get; set; } = new ObservableCollection<Model.RatingType>();
        Model.RatingType _selectedRatingType = null;
        public Model.RatingType SelectedRatingType
        {
            get { return _selectedRatingType; }
            set { SetProperty(ref _selectedRatingType, value); }
        }

        string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        int _acceptedOfferId;
        public int AcceptedOfferId
        {
            get { return _acceptedOfferId; }
            set { SetProperty(ref _acceptedOfferId, value); }
        }

        string _ratingTypeError = string.Empty;
        public string RatingTypeError
        {
            get { return _ratingTypeError; }
            set { SetProperty(ref _ratingTypeError, value); }
        }
        bool _ratingTypeErrorVisible;
        public bool RatingTypeErrorVisible
        {
            get { return _ratingTypeErrorVisible; }
            set { SetProperty(ref _ratingTypeErrorVisible, value); }
        }

        string _descriptionError = string.Empty;
        public string DescriptionError
        {
            get { return _descriptionError; }
            set { SetProperty(ref _descriptionError, value); }
        }
        bool _descriptionErrorVisible;
        public bool DescriptionErrorVisible
        {
            get { return _descriptionErrorVisible; }
            set { SetProperty(ref _descriptionErrorVisible, value); }
        }

        bool _showEditButton;
        public bool ShowEditButton
        {
            get { return _showEditButton; }
            set { SetProperty(ref _showEditButton, value); }
        }

        bool _haveActiveOffers;
        public bool HaveActiveOffers
        {
            get { return _haveActiveOffers; }
            set { SetProperty(ref _haveActiveOffers, value); }
        }
        bool _activeRequest = true;
        public bool ActiveRequest
        {
            get { return _activeRequest; }
            set { SetProperty(ref _activeRequest, value); }
        }
        bool _inActiveRequest;
        public bool InActiveRequest
        {
            get { return _inActiveRequest; }
            set { SetProperty(ref _inActiveRequest, value); }
        }

        #endregion
        public ICommand InitCommand { get; set; }
        public ICommand RequestFinishedCommand { get; set; }
        public ICommand LeaveFeedbackCommand { get; set; }
        
        private readonly AuthService _authService = new AuthService();
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _addressService = new APIService("address");
        private readonly APIService _countryService = new APIService("country");
        private readonly APIService _statusService = new APIService("status");
        private readonly APIService _offerService = new APIService("offer");
        private readonly APIService _notificationService = new APIService("notification");
        private readonly APIService _ratingTypeService = new APIService("ratingtype");
        private readonly APIService _ratingService = new APIService("rating");

        public RequestDetailsViewModel()
        {
            InitCommand = new Command(async () => await Init());
            RequestFinishedCommand = new Command(async () => await RequestFinished());
            LeaveFeedbackCommand = new Command(async () => await LeaveFeedback());
        }

        private bool isValid()
        {
            HideErrors();
            var valid = true;

            if (_selectedRatingType == null)
            {
                RatingTypeErrorVisible = true;
                RatingTypeError = Constants.SelectFeedback;
                valid = false;
            }

            if (_description.Length < 5)
            {
                DescriptionErrorVisible = true;
                DescriptionError = Constants.EnterValidValue;
                valid = false;
            }

            return valid;
        }

        void HideErrors()
        {
            RatingTypeErrorVisible = DescriptionErrorVisible = false;
        }

        public async Task LeaveFeedback()
        {
            if (!isValid())
            {
                return;
            }

            var request = new RatingUpsertRequest
            {
                Description = Description,
                RatingTypeId = SelectedRatingType.RatingTypeId,
                RequestId = Id,
                SupplierId = SupplierId
            };

            var rating = await _ratingService.Insert<Rating>(request);

            var notificationRequest = new NotificationInsertRequest
            {
                CreatedAt = DateTime.Now,
                ItemId = rating.RatingId,
                NotificationTypeId = (int)NotificationType.Feedback,
                UserFromId = ClientId,
                UserToId = SupplierId
            };

            await _notificationService.Insert<Model.Notification>(notificationRequest);

            await Init();
        }

        public async Task RequestFinished()
        {
            var request = new OfferUpdateRequest
            {
                OfferStatusId = (int)Models.OfferStatus.Finished
            };

            await _offerService.Update<Offer>(AcceptedOfferId, request);


            var notificationRequest = new NotificationInsertRequest
            {
                CreatedAt = DateTime.Now,
                ItemId = Id,
                NotificationTypeId = (int)NotificationType.OfferFinished,
                UserFromId = ClientId,
                UserToId = SupplierId
            };

            await _notificationService.Insert<Model.Notification>(notificationRequest);

            await UpdateStatus((int)Models.Status.Finished);

            await Init();
        }

        public async Task Init()
        {
            var request = await _requestService.GetById<Request>(Id);
            
            if (request.Inactive == true)
            {
                InActiveRequest = true;
                ActiveRequest = false;
                return;
            }
            InitRequest(request);
            var address = await _addressService.GetById<Address>(request.DeliveryAddress);
            InitAddress(address);
            var country = await _countryService.GetById<Country>((int)address.CountryId);
            InitCountry(country);
            var status = await _statusService.GetById<Model.Status>(request.StatusId);
            InitStatus(status);

            Address = $"{country.Name}, {address.ZipCode}, {address.City}";
            IsSupplier = JWTService.DecodeJWTRole() == Role.Supplier;
            IsClient = !IsSupplier;

            if (IsClient)
            {
                var searchRequest = new OfferSearchRequest
                {
                    RequestId = Id,
                    OfferStatusId = (int)Models.OfferStatus.Active
                };
                var offerList = await _offerService.GetAll<List<Offer>>(searchRequest);

                if (offerList.Count == 0)
                {
                    HaveAcceptedOffer = await RequestHaveAcceptedOffer();
                    HaveFinishedOffer = await RequestHaveFinishedOffer();
                    HaveActiveOffers = await RequestHaveActiveOffer();
                    var finishedOffer = await RequestHaveFinishedOfferWithoutRating();

                    if (!HaveAcceptedOffer && !finishedOffer)
                    {
                        ShowEditButton = true;
                    }

                    if (HaveFinishedOffer)
                    {
                        var list = await _ratingTypeService.GetAll<List<Model.RatingType>>();

                        RatingTypeList.Clear();
                        foreach (var rt in list)
                        {
                            RatingTypeList.Add(rt);
                        }
                    }
                }
                else
                {
                    ShowList = true;
                }

                OfferList.Clear();
                foreach (var offer in offerList)
                {
                    var supplier = await _authService.GetById(offer.UserId);
                    var supplierAddress = await _addressService.GetById<Address>((int)supplier.AddressId);
                    var supplierCountry = await _countryService.GetById<Country>((int)supplierAddress.CountryId);
                    var user = await _authService.GetById(offer.UserId);
                    var newOffer = new RequestDetailsOffers
                    {
                        Company = user.Company,
                        UserFromId = offer.UserId,
                        Address = supplierCountry.Name + ", " + supplierAddress.City,
                        OfferId = offer.OfferId
                    };

                    OfferList.Add(newOffer);
                }
                OffersHeight = OfferList.Count * 45;
            }
            else
            {
                await InitFieldsVisibility();
            }

            var recommendedRequests = await _requestService.RecommendRequest<List<Request>>(Id);

            RecommendedRequests.Clear();
            foreach (var recRequest in recommendedRequests)
            {
                var toAddress = await _addressService.GetById<Address>(recRequest.DeliveryAddress);
                var toCountry = await _countryService.GetById<Country>((int)toAddress.CountryId);
                var fromUser = await _authService.GetById(recRequest.ClientId);
                var fromAddress = await _addressService.GetById<Address>((int)fromUser.AddressId);
                var fromCountry = await _countryService.GetById<Country>((int)fromAddress.CountryId);
                var requestModel = new RequestModel
                {
                    FromCountry = fromCountry.Name,
                    Price = recRequest.Price,
                    RequestId = recRequest.RequestId,
                    ToCountry = toCountry.Name,
                    FullName = $"{fromUser.FirstName} {fromUser.LastName}"
                };

                RecommendedRequests.Add(requestModel);
            }

            if (RecommendedRequests.Count > 0)
            {
                RecommendShowList = true;
            }
            else
            {
                RecommendShowList = false;
            }
        }

        private async Task<bool> RequestHaveAcceptedOffer()
        {
            var searchRequest = new OfferSearchRequest
            {
                RequestId = Id,
                OfferStatusId = (int)Models.OfferStatus.Accepted
            };
            var offerList = await _offerService.GetAll<List<Offer>>(searchRequest);

            if (offerList.Count > 0)
            {
                AcceptedOfferId = offerList[0].OfferId;
                SupplierId = offerList[0].UserId;
                return true;
            } else
            {
                return false;
            }
        }

        private async Task<bool> RequestHaveFinishedOffer()
        {
            var searchRequest = new OfferSearchRequest
            {
                RequestId = Id,
                OfferStatusId = (int)Models.OfferStatus.Finished
            };
            var offerList = await _offerService.GetAll<List<Offer>>(searchRequest);

            if (offerList.Count > 0)
            {
                SupplierId = offerList[0].UserId;

                var request = new RatingSearchRequest
                {
                    RequestId = Id
                };

                var ratingList = await _ratingService.GetAll<List<Rating>>(request);

                if (ratingList.Count > 0)
                {
                    return false;
                }
                return true;
            }

            return false;
        }

        private async Task<bool> RequestHaveFinishedOfferWithoutRating()
        {
            var searchRequest = new OfferSearchRequest
            {
                RequestId = Id,
                OfferStatusId = (int)Models.OfferStatus.Finished
            };
            var offerList = await _offerService.GetAll<List<Offer>>(searchRequest);

            if (offerList.Count > 0)
            {
                return true;
            }

            return false;
        }

        private async Task<bool> RequestHaveActiveOffer()
        {
            var searchRequest = new OfferSearchRequest
            {
                RequestId = Id,
                OfferStatusId = (int)Models.OfferStatus.Active
            };
            var offerList = await _offerService.GetAll<List<Offer>>(searchRequest);

            if (offerList.Count > 0)
            {
                return true;
            }

            return false;
        }

        public async Task SendOffer()
        {
            var request = new OfferInsertRequest
            {
                CreatedAt = DateTime.Now,
                OfferStatusId = (int)Models.OfferStatus.Active,
                RequestId = Id,
                UserId = UserId
            };

            await _offerService.Insert<Offer>(request);
        }

        public async Task SendNotification()
        {
            var request = new NotificationInsertRequest
            {
                CreatedAt = DateTime.Now,
                NotificationTypeId = (int)NotificationType.NewRequest,
                UserFromId = UserId,
                UserToId = ClientId,
                ItemId = Id
            };

            await _notificationService.Insert<Model.Notification>(request);
        }

        public async Task SendNotifcationAccept(int SupplierId)
        {
            var request = new NotificationInsertRequest
            {
                CreatedAt = DateTime.Now,
                ItemId = Id,
                NotificationTypeId = (int)NotificationType.OfferAccepted,
                UserFromId = UserId,
                UserToId = SupplierId
            };

            await _notificationService.Insert<Model.Notification>(request);
        }

        public async Task SendNotifcationReject(int SupplierId)
        {
            var request = new NotificationInsertRequest
            {
                CreatedAt = DateTime.Now,
                ItemId = Id,
                NotificationTypeId = (int)NotificationType.OfferRejected,
                UserFromId = UserId,
                UserToId = SupplierId
            };

            await _notificationService.Insert<Model.Notification>(request);
        }


        public async Task AcceptOffer(int offerId, int supplierId)
        {
            var request = new OfferUpdateRequest();
            foreach (var offer in OfferList)
            {
                if (offer.OfferId == offerId)
                {
                    request.OfferStatusId = (int)Models.OfferStatus.Accepted;
                    await _offerService.Update<Offer>(offer.OfferId, request);
                    await SendNotifcationAccept(offer.UserFromId);
                }
                else
                {
                    request.OfferStatusId = (int)Models.OfferStatus.Rejected;
                    await _offerService.Update<Offer>(offer.OfferId, request);
                    await SendNotifcationReject(offer.UserFromId);
                }
            }

           await UpdateStatus((int)Models.Status.Accepted);
        }

        private async Task UpdateStatus(int StatusId)
        {
            var requestRequest = new RequestUpdateRequest
            {
                AdditionalInformation = AdditionalInformation,
                Date = Date,
                Price = Price,
                Rooms = Rooms,
                TotalWeightApprox = TotalWeightApprox,
                TransportDistanceApprox = TransportDistanceApprox,
                StatusId = StatusId
            };

            await _requestService.Update<Request>(Id, requestRequest);
        }

        public async Task RejectOffer(int offerId)
        {
            var request = new OfferUpdateRequest
            {
                OfferStatusId = (int)Models.OfferStatus.Rejected
            };

            await _offerService.Update<Offer>(offerId, request);
        }

        private async Task InitFieldsVisibility()
        {
            _userId = int.Parse(JWTService.DecodeJWT());
            
            var offerRequest = new OfferSearchRequest
            {
                RequestId = Id,
                OfferStatusId = (int)Models.OfferStatus.Accepted
            };

            var allAcceptedOffers = await _offerService.GetAll<List<Offer>>(offerRequest);
            offerRequest.UserId = _userId;

            var acceptedOffers = allAcceptedOffers.Where(a => a.UserId == _userId).ToList();

            offerRequest.OfferStatusId = (int)Models.OfferStatus.Active;
            var activeOffers = await _offerService.GetAll<List<Offer>>(offerRequest);
        
            offerRequest.OfferStatusId = (int)Models.OfferStatus.Finished;
            var finishedOffers = await _offerService.GetAll<List<Offer>>(offerRequest);
            offerRequest.OfferStatusId = (int)Models.OfferStatus.Rejected;
            var rejectedOffers = await _offerService.GetAll<List<Offer>>(offerRequest);


            if (activeOffers.Count == 0 && acceptedOffers.Count == 0 && finishedOffers.Count == 0 && allAcceptedOffers.Count == 0)
            {
                SendOfferVisible = true;
            }
            else
            {
                SendOfferVisible = false;
            }

            if (finishedOffers.Count > 0)
            {
                OfferSendMessageVisible = false;
                OfferRejected = false;
                OfferFinished = true;
                OfferAcceptedVisible = false;
            }
            else if (activeOffers.Count > 0)
            {
                OfferSendMessageVisible = true;
                OfferRejected = false;
                OfferFinished = false;
                OfferAcceptedVisible = false;
            }
            else if (acceptedOffers.Count > 0)
            {
                OfferSendMessageVisible = false;
                OfferRejected = false;
                OfferFinished = false;
                OfferAcceptedVisible = true;
            }
            else if (rejectedOffers.Count > 0)
            {
                OfferSendMessageVisible = false;
                OfferRejected = true;
                OfferFinished = false;
                OfferAcceptedVisible = false;
            }
            
        }
        private void InitRequest(Request request)
        {
            Date = request.Date;
            Price = request.Price;
            Rooms = request.Rooms;
            TotalWeightApprox = request.TotalWeightApprox;
            AdditionalInformation = request.AdditionalInformation;
            StatusId = request.StatusId;
            ClientId = request.ClientId;
            UserId = int.Parse(JWTService.DecodeJWT());
        }

        private void InitAddress(Address address)
        {
            City = address.City;
            Street = address.Street;
            ZipCode = address.ZipCode;
            Additional = address.AdditionalAddress;

        }

        private void InitCountry(Country country)
        {
            Country = country.Name;
        }

        private void InitStatus(Model.Status status)
        {
            Status = status.Name;

            if (status.StatusId == (int)EStatus.Pending)
            {
                StatusColor = Color.LightSalmon.ToHex();
            }
            else if (status.StatusId == (int)EStatus.Accepted)
            {
                StatusColor = Color.LimeGreen.ToHex();
            }
            else
            {
                StatusColor = Color.DodgerBlue.ToHex();
            }
        }

        public async Task DeleteRequest()
        {
            var offerRequest = new OfferSearchRequest
            {
                RequestId = Id
            };

            var offers = await _offerService.GetAll<List<MoveMe.Model.Offer>>(offerRequest);

            foreach (var item in offers)
            {
                await _offerService.Delete(item.OfferId);
            }

            var request = new RequestUpdateRequest
            {
                AdditionalInformation = AdditionalInformation,
                Date = Date,
                Price = Price,
                Rooms = Rooms,
                StatusId = StatusId,
                TotalWeightApprox = TotalWeightApprox,
                TransportDistanceApprox = TransportDistanceApprox,
                InActive = true
            };

            await _requestService.Update<Request>(Id, request);
        }
    }
}
