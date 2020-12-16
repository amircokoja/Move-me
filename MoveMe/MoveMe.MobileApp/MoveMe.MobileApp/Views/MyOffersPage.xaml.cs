
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

            await Navigation.PushAsync(new ClientRequestDetailsPage(offer.RequestId));
        }
    }
}