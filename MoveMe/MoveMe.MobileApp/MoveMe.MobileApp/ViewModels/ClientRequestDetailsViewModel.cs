using MoveMe.MobileApp.Services;
using MoveMe.Model;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class ClientRequestDetailsViewModel : BaseViewModel
    {

        #region Properties
        int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
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
        #endregion

        public ICommand InitCommand { get; set; }
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _addressService = new APIService("address");
        private readonly APIService _countryService = new APIService("country");
        private readonly APIService _statusService = new APIService("status");
        private readonly int id;

        public ClientRequestDetailsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {
            var request = await _requestService.GetById<Request>(Id);
            InitRequest(request);
            var address = await _addressService.GetById<Address>(request.DeliveryAddress);
            InitAddress(address);
            var country = await _countryService.GetById<Country>((int)address.CountryId);
            InitCountry(country);
            var status = await _statusService.GetById<Status>(request.StatusId);
            InitStatus(status);
        }

        private void InitRequest(Request request)
        {
            Date = request.Date;
            Price = request.Price;
            Rooms = request.Rooms;
            TotalWeightApprox = request.TotalWeightApprox;
            AdditionalInformation = request.AdditionalInformation;
            StatusId = request.StatusId;
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

        private void InitStatus(Status status)
        {
            Status = status.Name;
        }
    }
}
