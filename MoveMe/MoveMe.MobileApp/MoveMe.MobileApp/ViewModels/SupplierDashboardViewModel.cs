using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using MoveMe.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class SupplierDashboardViewModel : BaseViewModel
    {
        public ICommand InitCommand { get; set; }
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _addressService = new APIService("address");
        private readonly APIService _countryService = new APIService("country");
        public SupplierDashboardViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<ClientDashboardRequest> PendingRequests { get; set; } = new ObservableCollection<ClientDashboardRequest>();

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
        public int _pendingHeight = 0;
        public int PendingHeight
        {
            get { return _pendingHeight; }
            set { SetProperty(ref _pendingHeight, value); }
        }
      
        #endregion


        public async Task Init()
        {
            PendingRequests.Clear();

            var id = int.Parse(JWTService.DecodeJWT());
            var search = new Model.Requests.RequestSearchRequest
            {
                ShowInactive = false,
                StatusId = (int)Models.Status.Pending
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

                IsPendingVisible = true;
                IsPendingMessageVisible = false;
                PendingRequests.Add(newRequest);
            }
            PendingHeight = PendingRequests.Count * 36;
        }
    }
}
