using MoveMe.MobileApp.ViewModels;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        RegisterViewModel model = null;
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = model = new RegisterViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void Entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
           if (model != null && model.PhoneNumber.Length != 0)
            {
                if (Regex.IsMatch(model.PhoneNumber, "[^0-9]"))
                {
                    model.PhoneNumber = model.PhoneNumber.Remove(model.PhoneNumber.Length - 1);
                }
            }
        }

        private void Entry_PropertyChanged_1(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (model != null && model.ZipCode.Length != 0)
            {
                if (Regex.IsMatch(model.ZipCode, "[^0-9]"))
                {
                    model.ZipCode = model.ZipCode.Remove(model.ZipCode.Length - 1);
                }
            }
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}