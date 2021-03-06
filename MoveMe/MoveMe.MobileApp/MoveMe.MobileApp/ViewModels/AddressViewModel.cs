﻿using MoveMe.MobileApp.Models;
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
    public class AddressViewModel : BaseViewModel
    {
        #region Properties
        int _userId;
        public int UserId
        {
            get { return _userId; }
            set { SetProperty(ref _userId, value); }
        }
        string _street = string.Empty;
        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }
        string _city = string.Empty;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }
        string _zipCode = string.Empty;
        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode, value); }
        }
        string _additionalAddress = string.Empty;
        public string AdditionalAddress
        {
            get { return _additionalAddress; }
            set { SetProperty(ref _additionalAddress, value); }
        }

        public ObservableCollection<Country> CountryList { get; set; } = new ObservableCollection<Country>();
        Country _selectedCountry = null;
        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set { SetProperty(ref _selectedCountry, value); }
        }

        public int SelectedIndex;

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
        string _streetError = string.Empty;
        public string StreetError
        {
            get { return _streetError; }
            set { SetProperty(ref _streetError, value); }
        }
        string _additionalError = string.Empty;
        public string AdditionalError
        {
            get { return _additionalError; }
            set { SetProperty(ref _additionalError, value); }
        }
        bool _additionalErrorVisible;
        public bool AdditionalErrorVisible
        {
            get { return _additionalErrorVisible; }
            set { SetProperty(ref _additionalErrorVisible, value); }
        }
        bool _streetErrorVisible;
        public bool StreetErrorVisible
        {
            get { return _streetErrorVisible; }
            set { SetProperty(ref _streetErrorVisible, value); }
        }

        bool _showMessage;
        public bool ShowMessage
        {
            get { return _showMessage; }
            set { SetProperty(ref _showMessage, value); }
        }

        public int AddressId { get; set; }
        #endregion

        private readonly AuthService _authService = new AuthService();
        private readonly APIService _addressService = new APIService("address");
        private readonly APIService _countryService = new APIService("country");
        public ICommand InitCommand { get; set; }
        public AddressViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public async Task Init()
        {
            _userId = int.Parse(JWTService.DecodeJWT());
            var user = await _authService.GetById(_userId);
            AddressId = (int)user.AddressId;
            var address = await _addressService.GetById<Address>((int)user.AddressId);
            InitProperties(address);

            var countries = await _countryService.GetAll<List<Country>>();

            foreach (var item in countries)
            {
                CountryList.Add(item);
                if (item.CountryId == address.CountryId)
                {
                    SelectedCountry = item;
                }
            }
            SelectedIndex = (int)address.CountryId;
        }

        public async Task Submit()
        {
            if (!IsValid())
            {
                return;
            }

            var request = new AddressUpsertRequest
            {
                AdditionalAddress = AdditionalAddress,
                City = City,
                CountryId = SelectedCountry.CountryId,
                Street = Street,
                ZipCode = ZipCode
            };

            try
            {
                await _addressService.Update<Address>(AddressId, request);
                ShowMessage = true;
            }
            catch
            {}
        }

        private void InitProperties(Address address)
        {
            Street = address.Street;
            City = address.City;
            AdditionalAddress = address.AdditionalAddress;
            ZipCode = address.ZipCode;
        }

        private bool IsValid()
        {
            var valid = true;
            HideErrors();

            if (Street.Length < 3 || Street.Length > 50)
            {
                valid = false;
                StreetErrorVisible = true;
                StreetError = Constants.EnterValidStreet;
            }

            if (City.Length < 3 || City.Length > 40)
            {
                valid = false;
                CityErrorVisible = true;
                CityError = Constants.EnterValidCity;
            }

            if (ZipCode.Length < 4 || ZipCode.Length > 10)
            {
                valid = false;
                ZipCodeErrorVisible = true;
                ZipCodeError = Constants.EnterValidZipCode;
            }

            if (AdditionalAddress.Length > 60)
            {
                AdditionalError = Constants.TooLong;
                AdditionalErrorVisible = true;
                valid = false;
            }

            return valid;
        }

        private void HideErrors()
        {
            AdditionalErrorVisible = ZipCodeErrorVisible = CityErrorVisible = StreetErrorVisible = false;
        }
    }
}
