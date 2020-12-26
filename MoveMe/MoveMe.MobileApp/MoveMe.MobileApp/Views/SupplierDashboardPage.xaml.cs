using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupplierDashboardPage : ContentPage
    {
        SupplierDashboardViewModel model = null;

        public SupplierDashboardPage()
        {
            InitializeComponent();
            BindingContext = model = new SupplierDashboardViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user = e.SelectedItem as ClientDashboardRequest;

            await Navigation.PushAsync(new RequestDetailsPage(user.RequestId));
        }
    }
}