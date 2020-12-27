using MoveMe.MobileApp.Services;
using MoveMe.Model;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class SupplierDetailsViewModel : BaseViewModel
    {
        #region Properties
        int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
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

        string _company = string.Empty;
        public string Company
        {
            get { return _company; }
            set { SetProperty(ref _company, value); }
        }
        string _fullName = string.Empty;
        public string FullName
        {
            get { return _fullName; }
            set { SetProperty(ref _fullName, value); }
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

        byte[] _image;
        public byte[] Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
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

        string _country = string.Empty;
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }
        #endregion

        public ICommand InitCommand { get; set; }
        private readonly AuthService _authService = new AuthService();
        private readonly APIService _addressService = new APIService("address");
        private readonly APIService _countryService = new APIService("country");

        public SupplierDetailsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {
            IsSupplier = JWTService.DecodeJWTRole() == Role.Supplier;
            IsClient = !IsSupplier;

            var result = await this._authService.GetById(Id);
            InitProperties(result);
            var address = await _addressService.GetById<Address>((int)result.AddressId);
            InitAddress(address);
            var country = await _countryService.GetById<Country>((int)address.CountryId);
            InitCountry(country);
        }

        private void InitProperties(User user)
        {
            FullName = user.FirstName + " " + user.LastName;
            Company = user.Company;
            Image = user.Image;
            PhoneNumber = user.PhoneNumber;
            Email = user.Email;
        }

        private void InitAddress(Address address)
        {
            Street = address.Street;
            City = address.City;
            ZipCode = address.ZipCode;

            if (address.AdditionalAddress == null || address.AdditionalAddress == "")
            {
                AdditionalAddress = "No additional address";
            }
            else
            {
                AdditionalAddress = address.AdditionalAddress;
            }
        }

        private void InitCountry(Country country)
        {
            Country = country.Name;
        }
    }
}
