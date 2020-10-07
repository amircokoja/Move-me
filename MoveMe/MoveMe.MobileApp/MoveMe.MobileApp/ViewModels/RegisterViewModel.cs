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
            if (!Regex.IsMatch(_email, Constants.EmailRegex, RegexOptions.IgnoreCase))
            {
                EmailError = Constants.EnterValidEmail;
                valid = false;
            }

            if (_firstName.Length < 2)
            {
                FirstNameError = Constants.EnterValidValue;
                valid = false;
            }

            if (_lastName.Length < 2)
            {
                LastNameError = Constants.EnterValidValue;
                valid = false;
            }

            if (_city.Length < 2)
            {
                CityError = Constants.EnterValidCity;
                valid = false;
            }

            if (_phoneNumber.Length < 5)
            {
                PhoneNumberError = Constants.EnterValidValue;
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

            if (_password.Length < 4)
            {
                PasswordError = Constants.ErrorMinumumLength4;
                valid = false;
            }

            return valid;
        }

        void CleanErrors()
        {
            EmailError = FirstNameError = LastNameError = PhoneNumberError = StreetError = CityError = ZipCodeError = CountryError = PasswordError = "";
        }
    }
}
