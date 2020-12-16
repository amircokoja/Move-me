using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupplierAllRequestsPage : ContentPage
    {
        SupplierAllRequestsViewModel model = null;
        public SupplierAllRequestsPage()
        {
            InitializeComponent();
            BindingContext = model = new SupplierAllRequestsViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var request = e.SelectedItem as SupplierAllRequests;

            await Navigation.PushAsync(new ClientRequestDetailsPage(request.RequestId));
        }
    }
}