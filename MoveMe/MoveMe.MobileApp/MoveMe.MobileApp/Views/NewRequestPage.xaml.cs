
using MoveMe.MobileApp.ViewModels;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRequestPage : ContentPage
    {
        NewRequestViewModel model = null;

        public NewRequestPage(int? RequestId)
        {
            InitializeComponent();
            BindingContext = model = new NewRequestViewModel();
            model.RequestId = RequestId;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void Entry_PropertyChanged_1(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (model != null && model.Rooms.Length != 0)
            {
                if (Regex.IsMatch(model.Rooms, "[^0-9]"))
                {
                    model.Rooms = model.Rooms.Remove(model.Rooms.Length - 1);
                }
            }
        }

        private void Entry_PropertyChanged_2(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (model != null && model.TotalWeightApprox.Length != 0)
            {
                if (Regex.IsMatch(model.TotalWeightApprox, "[^0-9]"))
                {
                    model.TotalWeightApprox = model.TotalWeightApprox.Remove(model.TotalWeightApprox.Length - 1);
                }
            }
        }

        private void Entry_PropertyChanged_3(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (model != null && model.TransportDistanceApprox.Length != 0)
            {
                if (Regex.IsMatch(model.TransportDistanceApprox, "[^0-9]"))
                {
                    model.TransportDistanceApprox = model.TransportDistanceApprox.Remove(model.TransportDistanceApprox.Length - 1);
                }
            }
        }

        private void Entry_PropertyChanged_4(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (model != null && model.ZipCode.Length != 0)
            {
                if (Regex.IsMatch(model.ZipCode, "[^0-9]"))
                {
                    model.ZipCode = model.ZipCode.Remove(model.ZipCode.Length - 1);
                }
            } 
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            model.CleanErrors();
            if (!model.IsValid())
            {
                return;
            }

            bool answer = await DisplayAlert($"Confirm price", $"Price of your request will be ${model.Price}", "Ok", "Cancel");

            if (answer)
            {
                await model.Submit();
            }
        }
    }
}