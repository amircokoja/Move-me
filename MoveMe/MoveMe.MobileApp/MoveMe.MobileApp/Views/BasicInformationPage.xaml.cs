using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.ViewModels;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasicInformationPage : ContentPage
    {
        BasicInformationViewModel model = null;
        public BasicInformationPage()
        {
            InitializeComponent();
            BindingContext = model = new BasicInformationViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await model.Submit();
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
    }
}