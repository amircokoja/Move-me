using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using MoveMe.MobileApp.Views;
using MoveMe.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoveMe.MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly AuthService _authService = new AuthService();
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterNavigate { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            RegisterNavigate = new Command(() => NavigateToRegisterPage());
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        async Task Login()
        {
            IsBusy = true;

            if (!Regex.IsMatch(_email, Constants.EmailRegex, RegexOptions.IgnoreCase))
            {
                await Application.Current.MainPage.DisplayAlert(Constants.Error, Constants.EnterValidEmail, Constants.OK);
                return;
            }

            var loginRequest = new Model.Requests.LoginRequest
            {
                Email = _email,
                Password = _password,
                Roles = new List<string>
                {
                    Role.Client,
                    Role.Supplier
                }
            };

            try
            {
                var loginResult = await _authService.Login(loginRequest);
                APIService.token = loginResult.Token;
                APIService.roleId = GetRoleId(loginResult.Role);
                Application.Current.MainPage = new MainPage();
            }
            catch
            {}
        }

        void NavigateToRegisterPage()
        {
            Application.Current.MainPage = new RegisterPage();
        }

        private int GetRoleId(string role)
        {
            return role == Role.Client ? (int)RoleId.Client : (int)RoleId.Supplier;
        }
    }
}
