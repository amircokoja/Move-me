using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using MoveMe.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class ClientDashboardViewModel : BaseViewModel
    {
        public ICommand InitCommand { get; set; }
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _addressService = new APIService("address");
        private readonly APIService _countryService = new APIService("country");
        public ClientDashboardViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<ClientDashboardRequest> PendingRequests { get; set; } = new ObservableCollection<ClientDashboardRequest>();
        public ObservableCollection<ClientDashboardRequest> AcceptedRequests { get; set; } = new ObservableCollection<ClientDashboardRequest>();
        public ObservableCollection<ClientDashboardRequest> FinishedRequests { get; set; } = new ObservableCollection<ClientDashboardRequest>();

        #region Properties
        bool _isPendingVisible = false;
        public bool IsPendingVisible
        {
            get { return _isPendingVisible; }
            set { SetProperty(ref _isPendingVisible, value); }
        }

        public bool _isPendingMessageVisible = true;
        public bool IsPendingMessageVisible
        {
            get { return _isPendingMessageVisible; }
            set { SetProperty(ref _isPendingMessageVisible, value); }
        }

        public bool _isAcceptedVisible = false;
        public bool IsAcceptedVisible
        {
            get { return _isAcceptedVisible; }
            set { SetProperty(ref _isAcceptedVisible, value); }
        }
        public bool _isAcceptedMessageVisible = true;
        public bool IsAcceptedMessageVisible
        {
            get { return _isAcceptedMessageVisible; }
            set { SetProperty(ref _isAcceptedMessageVisible, value); }
        }
        public bool _isFinishedVisible = false;
        public bool IsFinishedVisible
        {
            get { return _isFinishedVisible; }
            set { SetProperty(ref _isFinishedVisible, value); }
        }
        public bool _isFinishedMessageVisible = true;
        public bool IsFinishedMessageVisible
        {
            get { return _isFinishedMessageVisible; }
            set { SetProperty(ref _isFinishedMessageVisible, value); }
        }
        #endregion


        public async Task Init()
        {
            PendingRequests.Clear();
            AcceptedRequests.Clear();
            FinishedRequests.Clear();

            var id = int.Parse(JWTService.DecodeJWT());
            var search = new Model.Requests.RequestSearchRequest
            {
                UserId = id
            };

            var requestList = await _requestService.GetAll<List<Request>>(search);

            foreach (var request in requestList)
            {
                var address = await _addressService.GetById<Address>(request.DeliveryAddress);
                var country = await _countryService.GetById<Country>((int)address.CountryId);

                var newRequest = new ClientDashboardRequest
                {
                    Address = country.Name + ", " + address.ZipCode + ", " + address.City, 
                    Date = request.Date,
                    Price = request.Price,
                    RequestId = request.RequestId
                };

                if (request.StatusId == (int)Models.Status.Pending)
                {
                    IsPendingVisible = true;
                    IsPendingMessageVisible = false;
                    PendingRequests.Add(newRequest);
                }
                else if (request.StatusId == (int)Models.Status.Accepted)
                {
                    IsAcceptedVisible = true;
                    IsAcceptedMessageVisible = false;
                    AcceptedRequests.Add(newRequest);
                }
                else
                {
                    IsFinishedVisible = true;
                    IsFinishedMessageVisible = false;
                    FinishedRequests.Add(newRequest);
                }
            }
        }
    }
}
