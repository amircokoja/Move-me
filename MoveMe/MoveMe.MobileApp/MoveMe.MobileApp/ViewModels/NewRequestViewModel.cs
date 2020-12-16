using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
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
        int? _requestId;
        public int? RequestId
        {
            get { return _requestId; }
            set { SetProperty(ref _requestId, value); }
        }
        int? _addressId;
        public int? AddressId
        {
            get { return _addressId; }
            set { SetProperty(ref _addressId, value); }
        }
        DateTime _minDate = DateTime.Now;
        public DateTime MinDate
        {
            get { return _minDate; }
            set { SetProperty(ref _minDate, value); }
        }

        DateTime _dateValue = DateTime.Now;
        public DateTime DateValue
        {
            get { return _dateValue; }
            set { SetProperty(ref _dateValue, value); }
        }
        string _dateError = string.Empty;
        public string DateError
        {
            get { return _dateError; }
            set { SetProperty(ref _dateError, value); }
        }
        bool _dateErrorVisible;
        public bool DateErrorVisible
        {
            get { return _dateErrorVisible; }
            set { SetProperty(ref _dateErrorVisible, value); }
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
        bool _priceErrorVisible;
        public bool PriceErrorVisible
        {
            get { return _priceErrorVisible; }
            set { SetProperty(ref _priceErrorVisible, value); }
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
        bool _roomsErrorVisible;
        public bool RoomsErrorVisible
        {
            get { return _roomsErrorVisible; }
            set { SetProperty(ref _roomsErrorVisible, value); }
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
        bool _totalWeightApproxErrorVisible;
        public bool TotalWeightApproxErrorVisible
        {
            get { return _totalWeightApproxErrorVisible; }
            set { SetProperty(ref _totalWeightApproxErrorVisible, value); }
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
        bool _transportDistanceApproxErrorVisible;
        public bool TransportDistanceApproxErrorVisible
        {
            get { return _transportDistanceApproxErrorVisible; }
            set { SetProperty(ref _transportDistanceApproxErrorVisible, value); }
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
        bool _streetErrorVisible;
        public bool StreetErrorVisible
        {
            get { return _streetErrorVisible; }
            set { SetProperty(ref _streetErrorVisible, value); }
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
        bool _cityErrorVisible;
        public bool CityErrorVisible
        {
            get { return _cityErrorVisible; }
            set { SetProperty(ref _cityErrorVisible, value); }
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
        bool _zipCodeErrorVisible;
        public bool ZipCodeErrorVisible
        {
            get { return _zipCodeErrorVisible; }
            set { SetProperty(ref _zipCodeErrorVisible, value); }
        }

        string _additional = string.Empty;
        public string Additional
        {
            get { return _additional; }
            set { SetProperty(ref _additional, value); }
        }

        string _countryError = string.Empty;
        public string CountryError
        {
            get { return _countryError; }
            set { SetProperty(ref _countryError, value); }
        }
        bool _countryErrorVisible;
        public bool CountryErrorVisible
        {
            get { return _countryErrorVisible; }
            set { SetProperty(ref _countryErrorVisible, value); }
        }
        public ObservableCollection<Country> CountryList { get; set; } = new ObservableCollection<Country>();
        Country _selectedCountry = null;
        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set { SetProperty(ref _selectedCountry, value); }

        }

        public int SelectedIndex = 0;

        #endregion

        public async Task Init()
        {
            Address address = new Address();

            if (RequestId != null)
            {
                var request = await _requestService.GetById<Request>((int)RequestId);
                address = await _addressService.GetById<Address>(request.DeliveryAddress);

                DateValue = request.Date;
                Rooms = request.Rooms;
                TotalWeightApprox = request.TotalWeightApprox;
                TransportDistanceApprox = request.TransportDistanceApprox;
                AdditionalInformation = request.AdditionalInformation;

                Street = address.Street;
                City = address.City;
                ZipCode = address.ZipCode;
                Additional = address.AdditionalAddress;
                AddressId = address.AddressId;
                Price = request.Price;
            }

            if (CountryList.Count == 0)
            {
                var countries = await _countryService.GetAll<List<Country>>();

                foreach (var item in countries)
                {
                    CountryList.Add(item);

                    if (address.CountryId != 0)
                    {
                        if (item.CountryId == address.CountryId)
                        {
                            SelectedCountry = item;

                        }

                    }
                }

                if (address.CountryId != null)
                {
                    SelectedIndex = (int)address.CountryId;
                }
            }
        }

        public void CalculatePrice()
        {
            if (!isValid())
            {
                Price = 0;
                return;
            }

            Price = Math.Round((0.7 * TransportDistanceApprox) * (0.8 * Rooms), 2);
        }

        public async Task Submit()
        {
            if (_price <= 0)
            {
                PriceErrorVisible = true;
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

                Address address;

                if (RequestId != null)
                {
                    address = await _addressService.Update<Address>((int)AddressId, addressRequest);
                    var req = new RequestUpdateRequest
                    {
                        AdditionalInformation = _additionalInformation,
                        Date = _dateValue,
                        Price = _price,
                        Rooms = _rooms,
                        TotalWeightApprox = _totalWeightApprox,
                        StatusId = (int)Models.Status.Pending,
                        TransportDistanceApprox = _transportDistanceApprox
                    };

                    var result = await _requestService.Update<Request>((int)RequestId, req);
                }
                else
                {
                    address = await _addressService.Insert<Address>(addressRequest);
                    int clientId = Int32.Parse(JWTService.DecodeJWT());
                    var request = new RequestInsertRequest
                    {
                        AdditionalInformation = _additionalInformation,
                        Created = DateTime.Now,
                        Date = _dateValue,
                        Price = _price,
                        Rooms = _rooms,
                        TotalWeightApprox = _totalWeightApprox,
                        ClientId = clientId,
                        StatusId = (int)Models.Status.Pending,
                        DeliveryAddress = address.AddressId,
                        TransportDistanceApprox = _transportDistanceApprox
                    };
                    var result = await _requestService.Insert<Request>(request);
                }
                await Application.Current.MainPage.DisplayAlert(Constants.RequestCreated, Constants.RequestCreatedMessage, Constants.OK);
                ClearForm();
            }
            catch
            {}
        }

        private bool isValid()
        {
            HideErrors();
            var valid = true;

            if (_rooms <= 0)
            {
                RoomsErrorVisible = true;
                RoomsError = Constants.EnterValidValue;
                valid = false;
            }

            if (DateValue < MinDate)
            {
                DateErrorVisible = true;
                DateError = Constants.EnterValidValue;
                valid = false;
            }

            if (_totalWeightApprox <= 0)
            {
                TotalWeightApproxErrorVisible = true;
                TotalWeightApproxError = Constants.EnterValidValue;
                valid = false;
            }

            if (_transportDistanceApprox <= 0)
            {
                TransportDistanceApproxErrorVisible = true;
                TransportDistanceApproxError = Constants.EnterValidValue;
                valid = false;
            }

            if (_city.Length < 3)
            {
                CityErrorVisible = true;
                CityError = Constants.EnterValidCity;
                valid = false;
            }

            if (_street.Length < 3)
            {
                StreetErrorVisible = true;
                StreetError = Constants.EnterValidStreet;
                valid = false;
            }

            if (_zipCode.Length < 4)
            {
                ZipCodeErrorVisible = true;
                ZipCodeError = Constants.EnterValidZipCode;
                valid = false;
            }

            if (_selectedCountry == null)
            {
                CountryErrorVisible = true;
                CountryError = Constants.SelectCountry;
                valid = false;
            }

            return valid;
        }

        void HideErrors()
        {
            DateErrorVisible = RoomsErrorVisible = TotalWeightApproxErrorVisible = TransportDistanceApproxErrorVisible = PriceErrorVisible = StreetErrorVisible = CityErrorVisible = ZipCodeErrorVisible = CountryErrorVisible = false;
        }

        void ClearForm()
        {
            Rooms = TotalWeightApprox = TransportDistanceApprox = 0;
            Price = 0;
            DateValue = DateTime.Now;
            City = ZipCode = Street = "";
            SelectedCountry = null;
        }

        public void CheckPriceValidity()
        {
            var valid = true;

            if (_rooms <= 0)
            {
                valid = false;
            }

            if (_totalWeightApprox <= 0)
            {
                valid = false;
            }

            if (_transportDistanceApprox <= 0)
            {
                valid = false;
            }

            if (_city.Length < 3)
            {
                valid = false;
            }

            if (_street.Length < 3)
            {
                valid = false;
            }

            if (_zipCode.Length < 4)
            {
                valid = false;
            }

            if (_selectedCountry == null)
            {
                valid = false;
            }

            if (!valid)
            {
                Price = 0;
            }
            else
            {
                Price = Math.Round((0.7 * TransportDistanceApprox) * (0.8 * Rooms), 2);
            }
        }
    }
}
