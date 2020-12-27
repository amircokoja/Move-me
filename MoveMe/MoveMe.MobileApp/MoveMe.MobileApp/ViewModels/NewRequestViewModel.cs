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
        public NewRequestViewModel()
        {
            InitCommand = new Command(async () => await Init());
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
        string _dateError = Constants.EnterValidValue;
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
        string _rooms = string.Empty;
        public string Rooms
        {
            get { return _rooms; }
            set { SetProperty(ref _rooms, value); }
        }
        string _roomsError = Constants.EnterValidValue;
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

        string _totalWeightApprox = string.Empty;
        public string TotalWeightApprox
        {
            get { return _totalWeightApprox; }
            set { SetProperty(ref _totalWeightApprox, value); }
        }
        string _totalWeightApproxError = Constants.EnterValidValue;
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

        string _transportDistanceApprox = string.Empty;
        public string TransportDistanceApprox
        {
            get { return _transportDistanceApprox; }
            set { SetProperty(ref _transportDistanceApprox, value); }
        }
        string _transportDistanceApproxError = Constants.EnterValidValue;
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
        string _streetError = Constants.EnterValidStreet;
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
        string _cityError = Constants.EnterValidCity;
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
        string _zipCodeError = Constants.EnterValidZipCode;
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

        string _countryError = Constants.SelectCountry;
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

        bool _additionalInfoErrorVisible;
        public bool AdditionalInfoErrorVisible
        {
            get { return _additionalInfoErrorVisible; }
            set { SetProperty(ref _additionalInfoErrorVisible, value); }
        }

        bool _additionalAddressErrorVisible;
        public bool AdditionalAddressErrorVisible
        {
            get { return _additionalAddressErrorVisible; }
            set { SetProperty(ref _additionalAddressErrorVisible, value); }
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
                Rooms = request.Rooms.ToString();
                TotalWeightApprox = request.TotalWeightApprox.ToString();
                TransportDistanceApprox = request.TransportDistanceApprox.ToString();
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

        public async Task Submit()
        {
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
                        Rooms = int.Parse(_rooms),
                        TotalWeightApprox = int.Parse(_totalWeightApprox),
                        StatusId = (int)Models.Status.Pending,
                        TransportDistanceApprox = int.Parse(_transportDistanceApprox)
                    };
                    var result = await _requestService.Update<Request>((int)RequestId, req);
                    await Application.Current.MainPage.DisplayAlert(Constants.RequestUpdated, Constants.RequestUpdatedMessage, Constants.OK);
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
                        Rooms = int.Parse(_rooms),
                        TotalWeightApprox = int.Parse(_totalWeightApprox),
                        ClientId = clientId,
                        StatusId = (int)Models.Status.Pending,
                        DeliveryAddress = address.AddressId,
                        TransportDistanceApprox = int.Parse(_transportDistanceApprox)
                    };
                    var result = await _requestService.Insert<Request>(request);
                    await Application.Current.MainPage.DisplayAlert(Constants.RequestCreated, Constants.RequestCreatedMessage, Constants.OK);
                }
                ClearForm();
            }
            catch
            {}
        }
        void HideErrors()
        {
            DateErrorVisible = RoomsErrorVisible = TotalWeightApproxErrorVisible = TransportDistanceApproxErrorVisible = StreetErrorVisible = CityErrorVisible = ZipCodeErrorVisible = CountryErrorVisible = false;
        }

        void ClearForm()
        {
            Price = 0;
            DateValue = DateTime.Now;
            Rooms = TotalWeightApprox = TransportDistanceApprox = City = ZipCode = Street = "";
            SelectedCountry = null;
        }

        public bool IsValid()
        {
            var valid = true;

            try
            {
                var roomInt = int.Parse(_rooms);
                if (roomInt <= 0)
                {
                    valid = false;
                    RoomsErrorVisible = true;
                    RoomsError = Constants.EnterValidValue;
                }
                else if (roomInt > 20)
                {
                    valid = false;
                    RoomsErrorVisible = true;
                    RoomsError = Constants.MaximumRooms;
                }
            }
            catch (Exception)
            {
                RoomsErrorVisible = true;
                valid = false;
            }

            try
            {
                if (int.Parse(_totalWeightApprox) <= 0 || int.Parse(_totalWeightApprox) > 10000000)
                {
                    valid = false;
                    TotalWeightApproxErrorVisible = true;
                }
            }
            catch (Exception)
            {
                valid = false;
                TotalWeightApproxErrorVisible = true;
            }

            try
            {
                if (int.Parse(_transportDistanceApprox) <= 0 || int.Parse(_transportDistanceApprox) > 10000000)
                {
                    valid = false;
                    TransportDistanceApproxErrorVisible = true;
                }
            }
            catch (Exception)
            {
                valid = false;
                TransportDistanceApproxErrorVisible = true;
            }

            if (_city.Length < 3 || _city.Length > 40)
            {
                valid = false;
                CityErrorVisible = true;
            }

            if (_street.Length < 3 || _street.Length > 50)
            {
                valid = false;
                StreetErrorVisible = true;
            }

            if (_zipCode.Length < 4 || _zipCode.Length > 10)
            {
                valid = false;
                ZipCodeErrorVisible = true;
            }

            if (_additionalInformation.Length > 10)
            {
                valid = false;
                AdditionalInfoErrorVisible = true;
            }
            if (_additional.Length > 10)
            {
                valid = false;
                AdditionalAddressErrorVisible = true;
            }

            if (_selectedCountry == null)
            {
                valid = false;
                CountryErrorVisible = true;
            }

            if (DateValue <= MinDate)
            {
                valid = false;
                DateErrorVisible = true;
            }

            if (!valid)
            {
                Price = 0;
            }
            else
            {
                Price = Math.Round((0.7 * int.Parse(TransportDistanceApprox)) * (0.8 * int.Parse(Rooms)), 2);
                HideErrors();
            }

            return valid;
        }

        public void CleanErrors()
        {
            DateErrorVisible = AdditionalAddressErrorVisible = CountryErrorVisible = AdditionalInfoErrorVisible = ZipCodeErrorVisible = StreetErrorVisible = CityErrorVisible =
                RoomsErrorVisible = TotalWeightApproxErrorVisible = TransportDistanceApproxErrorVisible = false;
        }
    }
}
