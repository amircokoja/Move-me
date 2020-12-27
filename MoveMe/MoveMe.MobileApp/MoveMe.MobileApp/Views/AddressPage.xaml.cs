using MoveMe.MobileApp.ViewModels;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressPage : ContentPage
    {
        AddressViewModel model = null;
        public AddressPage()
        {
            InitializeComponent();
            BindingContext = model = new AddressViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await model.Submit();
        }

        private void Entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (model != null && model.ZipCode.Length != 0)
            {
                if (Regex.IsMatch(model.ZipCode, "[^0-9]"))
                {
                    model.ZipCode = model.ZipCode.Remove(model.ZipCode.Length - 1);
                }
            }
        }
    }
}