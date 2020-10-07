using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using MoveMe.MobileApp.Views;
using MoveMe.Model;
using MoveMe.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class NewRequestViewModel : BaseViewModel
    {
        private readonly APIService _countryService = new APIService("country");
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _addressService = new APIService("address");
        public ICommand InitCommand { get; set; }
        public ICommand CalculatePriceCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
        public NewRequestViewModel()
        {
            InitCommand = new Command(async () => await Init());
            CalculatePriceCommand = new Command(() => CalculatePrice());
            SubmitCommand = new Command(async () => await Submit());
        }

        #region Properties
        public DateTime MinDate = DateTime.Now;

        DateTime _date = new DateTime();
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }
        string _dateError = string.Empty;
        public string DateError
        {
            get { return _dateError; }
            set { SetProperty(ref _dateError, value); }
        }
        double _price;
        public double Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }
        string _priceError = string.Empty;
        public string PriceError
        {
            get { return _priceError; }
            set { SetProperty(ref _priceError, value); }
        }
        int _rooms;
        public int Rooms
        {
            get { return _rooms; }
            set { SetProperty(ref _rooms, value); }
        }
        string _roomsError = string.Empty;
        public string RoomsError
        {
            get { return _roomsError; }
            set { SetProperty(ref _roomsError, value); }
        }

        int _totalWeightApprox;
        public int TotalWeightApprox
        {
            get { return _totalWeightApprox; }
            set { SetProperty(ref _totalWeightApprox, value); }
        }
        string _totalWeightApproxError = string.Empty;
        public string TotalWeightApproxError
        {
            get { return _totalWeightApproxError; }
            set { SetProperty(ref _totalWeightApproxError, value); }
        }

        int _transportDistanceApprox;
        public int TransportDistanceApprox
        {
            get { return _transportDistanceApprox; }
            set { SetProperty(ref _transportDistanceApprox, value); }
        }
        string _transportDistanceApproxError = string.Empty;
        public string TransportDistanceApproxError
        {
            get { return _transportDistanceApproxError; }
            set { SetProperty(ref _transportDistanceApproxError, value); }
        }

        string _additionalInformation = string.Empty;
        public string AdditionalInformation
        {
            get { return _additionalInformation; }
            set { SetProperty(ref _additionalInformation, value); }
        }

        string _street = string.Empty;
        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }
        string _streetError = string.Empty;
        public string StreetError
        {
            get { return _streetError; }
            set { SetProperty(ref _streetError, value); }
        }

        string _city = string.Empty;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }
        string _cityError = string.Empty;
        public string CityError
        {
            get { return _cityError; }
            set { SetProperty(ref _cityError, value); }
        }

        string _zipCode = string.Empty;
        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode, value); }
        }
        string _zipCodeError = string.Empty;
        public string ZipCodeError
        {
            get { return _zipCodeError; }
            set { SetProperty(ref _zipCodeError, value); }
        }

        string _additional = string.Empty;
        public string Additional
        {
            get { return _additional; }
            set { SetProperty(ref _additional, value); }
        }

        string _country = string.Empty;
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }
        string _countryError = string.Empty;
        public string CountryError
        {
            get { return _countryError; }
            set { SetProperty(ref _countryError, value); }
        }
        public ObservableCollection<Country> CountryList { get; set; } = new ObservableCollection<Country>();
        Country _selectedCountry = null;
        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                SetProperty(ref _selectedCountry, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }
#endregion

        public async Task Init()
        {
            if (CountryList.Count == 0)
            {
                var vrsteProizvodaList = await _countryService.GetAll<List<Country>>();

                foreach (var vrsteProizvoda in vrsteProizvodaList)
                {
                    CountryList.Add(vrsteProizvoda);
                }
            }
        }

        public void CalculatePrice()
        {
            CleanErrors();

            if (!isValid())
            {
                return;
            }

            Price = Math.Round((0.7 * TransportDistanceApprox) * (0.8 * Rooms), 2);
        }

        public async Task Submit()
        {
            if (_price <= 0)
            {
                PriceError = Constants.CalculatePrice;
                return;
            }

            try
            {
                var addressRequest = new AddressUpsertRequest
                {
                    AdditionalAddress = _additional,
                    City = _city,
                    CountryId = _selectedCountry.CountryId,
                    Street = _street,
                    ZipCode = _zipCode
                };

                var address = await _addressService.Insert<Address>(addressRequest);

                int clientId = Int32.Parse(JWTService.DecodeJWT());
                var request = new RequestInsertRequest
                {
                    AdditionalInformation = _additionalInformation,
                    Created = DateTime.Now,
                    Date = _date,
                    Price = _price,
                    Rooms = _rooms,
                    TotalWeightApprox = _totalWeightApprox,
                    ClientId = clientId,
                    StatusId = (int)Status.Pending,
                    DeliveryAddress = address.AddressId
                };

                var result = await _requestService.Insert<Request>(request);
                
                await Application.Current.MainPage.DisplayAlert(Constants.RequestCreated, Constants.RequestCreatedMessage, Constants.OK);
            }
            catch
            {}
        }

        private bool isValid()
        {
            var valid = true;

            if (_rooms <= 0)
            {
                RoomsError = Constants.EnterValidValue;
                valid = false;
            }

            if (_date == DateTime.MinValue)
            {
                DateError = Constants.EnterValidValue;
                valid = false;
            }

            if (_totalWeightApprox <= 0)
            {
                TotalWeightApproxError = Constants.EnterValidValue;
                valid = false;
            }

            if (_transportDistanceApprox <= 0)
            {
                TransportDistanceApproxError = Constants.EnterValidValue;
                valid = false;
            }

            if (_city.Length < 2)
            {
                CityError = Constants.EnterValidCity;
                valid = false;
            }

            if (_street.Length < 2)
            {
                StreetError = Constants.EnterValidStreet;
                valid = false;
            }

            if (_zipCode.Length < 4)
            {
                ZipCodeError = Constants.EnterValidZipCode;
                valid = false;
            }

            if (_selectedCountry == null)
            {
                CountryError = Constants.SelectCountry;
                valid = false;
            }

            return valid;
        }

        void CleanErrors()
        {
            RoomsError = TotalWeightApproxError = TransportDistanceApproxError = PriceError = StreetError = CityError = ZipCodeError = CountryError = "";
        }
    }
}
