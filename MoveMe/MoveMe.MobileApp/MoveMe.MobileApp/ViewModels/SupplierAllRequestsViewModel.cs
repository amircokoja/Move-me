using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using MoveMe.Model;
using MoveMe.Model.Requests;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class SupplierAllRequestsViewModel : BaseViewModel
    {
        int? _minimumPrice;
        public int? MinimumPrice
        {
            get { return _minimumPrice; }
            set { SetProperty(ref _minimumPrice, value); }
        }
        int? _maximumRooms;
        public int? MaximumRooms
        {
            get { return _maximumRooms; }
            set { SetProperty(ref _maximumRooms, value); }
        }
        Country _selectedCountry = null;
        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set { SetProperty(ref _selectedCountry, value); }

        }
        Model.Status _selectedStatus = null;
        public Model.Status SelectedStatus
        {
            get { return _selectedStatus; }
            set { SetProperty(ref _selectedStatus, value); }

        }

        bool _hideList;
        public bool HideList
        {
            get { return _hideList; }
            set { SetProperty(ref _hideList, value); }
        }
        bool _showList;
        public bool ShowList
        {
            get { return _showList; }
            set { SetProperty(ref _showList, value); }
        }

        public ICommand InitCommand { get; set; }
        private readonly AuthService _authService = new AuthService();
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _statusService = new APIService("status");
        private readonly APIService _countryService = new APIService("country");
        private readonly APIService _addressService = new APIService("address");
        public ObservableCollection<RequestModel> RequestList { get; set; } = new ObservableCollection<RequestModel>();
        public ObservableCollection<Model.Status> StatusList { get; set; } = new ObservableCollection<Model.Status>();
        public ObservableCollection<Country> CountryList { get; set; } = new ObservableCollection<Country>();

        public SupplierAllRequestsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {
            if (CountryList.Count == 0)
            {
                var anyCountry = new Country
                {
                    CountryId = -1,
                    Name = "Any"
                };

                CountryList.Add(anyCountry);
                var countryList = await _countryService.GetAll<List<Country>>();
                foreach (var country in countryList)
                {
                    CountryList.Add(country);
                }
              
                SelectedCountry = anyCountry;
            }
            if (StatusList.Count == 0)
            {
                var anyStatus = new Model.Status
                {
                    StatusId = -1,
                    Name = "Any"
                };

                StatusList.Add(anyStatus);
                var statusList = await _statusService.GetAll<List<Model.Status>>();
                foreach (var status in statusList)
                {
                    StatusList.Add(status);
                }
                SelectedStatus = anyStatus;
            }

            var searchRequest = new RequestSearchRequest
            {
                MaximumRooms = _maximumRooms,
                MinimumPrice = _minimumPrice,
                ShowInactive = false
            };

            if (SelectedCountry != null && SelectedCountry.CountryId != -1)
            {
                searchRequest.CountryId = SelectedCountry.CountryId;
            } 

            if (SelectedStatus != null && SelectedStatus.StatusId != -1)
            {
                searchRequest.StatusId = SelectedStatus.StatusId;
            }

            var requestList = await _requestService.GetAll<List<Request>>(searchRequest);
            RequestList.Clear();
            foreach (var request in requestList)
            {
                var user = await _authService.GetById(request.ClientId);
                var userAddress = await _addressService.GetById<Address>((int)user.AddressId);
                var userCountry = await _countryService.GetById<Country>((int)userAddress.CountryId);

                var requestAddress = await _addressService.GetById<Address>(request.DeliveryAddress);
                var requestCountry = await _countryService.GetById<Country>((int)requestAddress.CountryId);

                var newRequest = new RequestModel
                {
                    FromCountry = userCountry.Name,
                    FullName = user.FirstName + " " + user.LastName,
                    Price = request.Price,
                    RequestId = request.RequestId,
                    ToCountry = requestCountry.Name
                };
                RequestList.Add(newRequest);
            }

            if (RequestList.Count > 0)
            {
                ShowList = true;
                HideList = false;
            }
            else
            {
                ShowList = false;
                HideList = true;
            }
        }
    }
}
