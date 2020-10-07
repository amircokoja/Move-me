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


        public bool IsPendingMessageVisible = true;
        public bool IsAcceptedVisible = false;
        public bool IsAcceptedMessageVisible = true;
        public bool IsFinishedVisible = false;
        public bool IsFinishedMessageVisible = true;
        #endregion


        public async Task Init()
        {
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

                if (request.StatusId == (int)Status.Pending)
                {
                    PendingRequests.Add(newRequest);
                    IsPendingVisible = true;
                    IsPendingMessageVisible = false;
                }
                else if (request.StatusId == (int)Status.Accepted)
                {
                    AcceptedRequests.Add(newRequest);
                    IsAcceptedVisible = true;
                    IsAcceptedMessageVisible = false;
                }
                else
                {
                    FinishedRequests.Add(newRequest);
                    IsFinishedVisible = true;
                    IsFinishedMessageVisible = false;
                }
            }
        }
    }
}
