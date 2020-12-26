
using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyOffersPage : ContentPage
    {
        MyOffersViewModel model = null;
        public MyOffersPage()
        {
            InitializeComponent();
            BindingContext = model = new MyOffersViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var offer = e.SelectedItem as MyOffers;

            await Navigation.PushAsync(new RequestDetailsPage(offer.RequestId));
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var id = int.Parse(Services.JWTService.DecodeJWT());
            await Navigation.PushAsync(new FeedbackPage(id));
        }
    }
}