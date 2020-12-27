using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequestDetailsPage : ContentPage
    {
        RequestDetailsViewModel model = null;
        public RequestDetailsPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new RequestDetailsViewModel();
            model.Id = id;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            bool answer = await DisplayAlert("Send offer?", "Are you sure that you want to send this offer?", "Yes", "No");

            if (answer)
            {
                await model.SendOffer();
                await model.SendNotification();
                await DisplayAlert("Offer sent", "Offer was sent successfully", "OK");
                await model.Init();
            }
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var offer = e.SelectedItem as RequestDetailsOffers;

            await Navigation.PushAsync(new SupplierDetailsPage(offer.UserFromId));
        }

        private async void Button_Clicked_1(object sender, System.EventArgs e)
        {
            bool answer = await DisplayAlert("Accept offer?", "All others offers will be rejected, if any!", "Yes", "No");
            if (answer)
            {
                var button = sender as Button;
                var offer = button.BindingContext as RequestDetailsOffers;
                await model.AcceptOffer(offer.OfferId, offer.UserFromId);
                await DisplayAlert("Offer accepted", "Offer is accepted", "OK");
                await model.Init();
            }
        }

        private async void Button_Clicked_2(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            var offer = button.BindingContext as RequestDetailsOffers;
            await model.RejectOffer(offer.OfferId);
            await model.SendNotifcationReject(offer.UserFromId);
            await DisplayAlert("Offer rejected", "Offer is rejected", "OK");
            await model.Init();
        }

        private async void Button_Clicked_3(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewRequestPage(model.Id));
        }

        private async void Button_Clicked_4(object sender, System.EventArgs e)
        {
            await model.DeleteRequest();
            await DisplayAlert("Request is deleted", "Request is successfully deleted", "OK");
            Application.Current.MainPage = new MainPage();
        }

        private async void Button_Clicked_5(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SupplierDetailsPage(model.ClientId));
        }

        private async void ListView_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            var request = e.SelectedItem as RequestModel;

            await Navigation.PushAsync(new RequestDetailsPage(request.RequestId));
        }

        private async void Button_Clicked_6(object sender, System.EventArgs e)
        {
            if (!model.isValid())
            {
                return;
            }

            await model.LeaveFeedback();
            await DisplayAlert("Success", "Feedback was sent successfully", "OK");
        }
    }
}