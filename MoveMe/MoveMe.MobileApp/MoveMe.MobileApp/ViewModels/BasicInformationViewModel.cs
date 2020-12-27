using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using MoveMe.Model;
using MoveMe.Model.Requests;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class BasicInformationViewModel : BaseViewModel
    {
        #region Properties
        int _userId;
        public int UserId
        {
            get { return _userId; }
            set { SetProperty(ref _userId, value); }
        }
        bool _isLoaded;
        public bool IsLoaded
        {
            get { return _isLoaded; }
            set { SetProperty(ref _isLoaded, value); }
        }

        bool _isClient;
        public bool IsClient
        {
            get { return _isClient; }
            set { SetProperty(ref _isClient, value); }
        }

        bool _isSupplier;
        public bool IsSupplier
        {
            get { return _isSupplier; }
            set { SetProperty(ref _isSupplier, value); }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        string _phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

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
        string _company = string.Empty;
        public string Company
        {
            get { return _company; }
            set { SetProperty(ref _company, value); }
        }

        string _companyError = string.Empty;
        public string CompanyError
        {
            get { return _companyError; }
            set { SetProperty(ref _companyError, value); }
        }
        bool _companyErrorVisible;
        public bool CompanyErrorVisible
        {
            get { return _companyErrorVisible; }
            set { SetProperty(ref _companyErrorVisible, value); }
        }
        string _firstNameError = string.Empty;
        public string FirstNameError
        {
            get { return _firstNameError; }
            set { SetProperty(ref _firstNameError, value); }
        }
        bool _firstNameErrorVisible;
        public bool FirstNameErrorVisible
        {
            get { return _firstNameErrorVisible; }
            set { SetProperty(ref _firstNameErrorVisible, value); }
        }
        string _lastNameError = string.Empty;
        public string LastNameError
        {
            get { return _lastNameError; }
            set { SetProperty(ref _lastNameError, value); }
        }
        bool _lastNameErrorVisible;
        public bool LastNameErrorVisible
        {
            get { return _lastNameErrorVisible; }
            set { SetProperty(ref _lastNameErrorVisible, value); }
        }
        string _emailError = string.Empty;
        public string EmailError
        {
            get { return _emailError; }
            set { SetProperty(ref _emailError, value); }
        }
        bool _emailErrorVisible;
        public bool EmailErrorVisible
        {
            get { return _emailErrorVisible; }
            set { SetProperty(ref _emailErrorVisible, value); }
        }
        string _phoneNumberError = string.Empty;
        public string PhoneNumberError
        {
            get { return _phoneNumberError; }
            set { SetProperty(ref _phoneNumberError, value); }
        }
        bool _phoneNumberErrorVisible;
        public bool PhoneNumberErrorVisible
        {
            get { return _phoneNumberErrorVisible; }
            set { SetProperty(ref _phoneNumberErrorVisible, value); }
        }

        bool _showMessage;
        public bool ShowMessage
        {
            get { return _showMessage; }
            set { SetProperty(ref _showMessage, value); }
        }
        #endregion

        private readonly AuthService _authService = new AuthService();
        public ICommand InitCommand { get; set; }
        public BasicInformationViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {
            IsLoaded = true;
            _userId = int.Parse(JWTService.DecodeJWT());
            var user = await _authService.GetById(_userId);
            IsSupplier = JWTService.DecodeJWTRole() == Role.Supplier;
            IsClient = !IsSupplier;
            InitProperties(user);
            IsLoaded = true;
        }

        public async Task Submit()
        {
            if (!IsValid())
            {
                return;
            }

            var request = new UserUpdateRequest
            {
                Email = Email,
                PhoneNumber = PhoneNumber
            };
            if (IsClient)
            {
                request.FirstName = FirstName;
                request.LastName = LastName;
            }
            else
            {
                request.Company = Company;
            }

            try
            {
                await _authService.Update(UserId, request);
                ShowMessage = true;
            }
            catch
            {}
        }

        private void InitProperties(User user)
        {
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Company = user.Company;
        }

        public bool IsValid()
        {
            HideErrors();

            var valid = true;
            if (!Regex.IsMatch(_email, Constants.EmailRegex, RegexOptions.IgnoreCase) || _email.Length > 100)
            {
                EmailError = Constants.EnterValidEmail;
                EmailErrorVisible = true;
                valid = false;
            }

            if (IsClient)
            {
                if (_firstName.Length < 2 || _firstName.Length > 40)
                {
                    FirstNameError = Constants.EnterValidValue;
                    FirstNameErrorVisible = true;
                    valid = false;
                }
                if (_lastName.Length < 2 || _lastName.Length > 40)
                {
                    LastNameErrorVisible = true;
                    LastNameError = Constants.EnterValidValue;
                    valid = false;
                }
            } 
            else
            {
                if (_company.Length < 2 || _company.Length > 30)
                {
                    CompanyErrorVisible = true;
                    CompanyError = Constants.EnterValidValue;
                    valid = false;
                }
            }

            if (_phoneNumber.Length < 8 || _phoneNumber.Length > 25)
            {
                PhoneNumberErrorVisible = true;
                PhoneNumberError = Constants.EnterValidValue;
                valid = false;
            }

            return valid;
        }

        void HideErrors()
        {
            EmailErrorVisible = FirstNameErrorVisible = LastNameErrorVisible = PhoneNumberErrorVisible = CompanyErrorVisible = false;
        }
    }
}
