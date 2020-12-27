using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Views;
using MoveMe.Model;
using MoveMe.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await Register());
            InitCommand = new Command(async () => await Init());
        }
        async Task Register()
        {
            IsBusy = true;

            CleanErrors();
            if (!IsValid())
            {
                return;
            }

            var registerRequest = new RegisterRequest
            {
                AdditionalAddress = Additional,
                City = City,
                ConfirmPassword = ConfirmPassword,
                CountryId = SelectedCountry.CountryId,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Password = Password,
                Street = Street,
                ZipCode = ZipCode,
                RoleId = (int)RoleId.Client,
                PhoneNumber = PhoneNumber,
                CreatedAt = DateTime.Now
            };

            try
            {
                await _authService.Register(registerRequest);
                await Application.Current.MainPage.DisplayAlert(Constants.AccountCreated, Constants.AccountCreatedMessage, Constants.OK);
                Application.Current.MainPage = new LoginPage();
            }
            catch {}
        }

        public async Task Init()
        {
            if (CountryList.Count == 0)
            {
                var countryList = await _countryService.GetAll<List<Country>>();

                foreach (var country in countryList)
                {
                    CountryList.Add(country);
                }
            }
        }

        public bool IsValid()
        {
            var valid = true;
            if (!Regex.IsMatch(_email, Constants.EmailRegex, RegexOptions.IgnoreCase) || _email.Length > 100)
            {
                EmailError = Constants.EnterValidEmail;
                valid = false;
            }

            if (_firstName.Length < 2 || _firstName.Length > 40)
            {
                FirstNameError = Constants.EnterValidValue;
                valid = false;
            }

            if (_lastName.Length < 2 || _lastName.Length > 40)
            {
                LastNameError = Constants.EnterValidValue;
                valid = false;
            }

            if (_city.Length < 3 || _city.Length > 40)
            {
                CityError = Constants.EnterValidCity;
                valid = false;
            }

            if (_phoneNumber.Length < 8 || _phoneNumber.Length > 25)
            {
                PhoneNumberError = Constants.EnterValidValue;
                valid = false;
            }

            if (_street.Length < 3 || _street.Length > 50)
            {
                StreetError = Constants.EnterValidStreet;
                valid = false;
            }

            if (_zipCode.Length < 4 || _zipCode.Length > 10)
            {
                ZipCodeError = Constants.EnterValidZipCode;
                valid = false;
            }


            if (_additional.Length > 60)
            {
                AdditionalError = Constants.TooLong;
                valid = false;
            }

            if (_selectedCountry == null)
            {
                CountryError = Constants.SelectCountry;
                valid = false;
            }

            if (_password.Length < 5)
            {
                PasswordError = Constants.ErrorMinumumLength5;
                valid = false;
            }
            else if (_password.Length > 40)
            {
                PasswordError = Constants.EnterValidValue;
                valid = false;
            }

            return valid;
        }

        void CleanErrors()
        {
            AdditionalError = EmailError = FirstNameError = LastNameError = PhoneNumberError = StreetError = CityError = ZipCodeError = CountryError = PasswordError = "";
        }
    }
}
