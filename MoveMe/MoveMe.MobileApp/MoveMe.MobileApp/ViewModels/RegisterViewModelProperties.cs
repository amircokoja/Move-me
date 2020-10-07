using MoveMe.MobileApp.Services;
using MoveMe.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MoveMe.MobileApp.ViewModels
{
    public partial class RegisterViewModel
    {
        private readonly AuthService _authService = new AuthService();
        private readonly APIService _countryService = new APIService("country");
        public ICommand RegisterCommand { get; set; }
        public ICommand InitCommand { get; set; }

        string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        string _lastName = string.Empty;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
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
        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        string _confirmPassword = string.Empty;
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { SetProperty(ref _confirmPassword, value); }
        }
        string _phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
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

        string _emailError = string.Empty;
        public string EmailError
        {
            get { return _emailError; }
            set { SetProperty(ref _emailError, value); }
        }
        string _firstNameError = string.Empty;
        public string FirstNameError
        {
            get { return _firstNameError; }
            set { SetProperty(ref _firstNameError, value); }
        }
        string _lastNameError = string.Empty;
        public string LastNameError
        {
            get { return _lastNameError; }
            set { SetProperty(ref _lastNameError, value); }
        }
        string _phoneNumberError = string.Empty;
        public string PhoneNumberError
        {
            get { return _phoneNumberError; }
            set { SetProperty(ref _phoneNumberError, value); }
        }
        string _streetError = string.Empty;
        public string StreetError
        {
            get { return _streetError; }
            set { SetProperty(ref _streetError, value); }
        }
        string _cityError = string.Empty;
        public string CityError
        {
            get { return _cityError; }
            set { SetProperty(ref _cityError, value); }
        }
        string _zipCodeError = string.Empty;
        public string ZipCodeError
        {
            get { return _zipCodeError; }
            set { SetProperty(ref _zipCodeError, value); }
        }
        string _passwordError = string.Empty;
        public string PasswordError
        {
            get { return _passwordError; }
            set { SetProperty(ref _passwordError, value); }
        }
        string _countryError = string.Empty;
        public string CountryError
        {
            get { return _countryError; }
            set { SetProperty(ref _countryError, value); }
        }
    }
}
