using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using MoveMe.MobileApp.ViewModels;
using MoveMe.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        DashboardViewModel model = null;
        public DashboardPage()
        {
            InitializeComponent();
            BindingContext = model = new DashboardViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            if (APIService.roleId == (int)RoleId.Supplier)
            {
                await Navigation.PushModalAsync(new MainPage()
                {
                    Detail = new NavigationPage(new SupplierDashboardPage())
                });
            }
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user = e.SelectedItem as ClientDashboardRequest;

            await Navigation.PushAsync(new RequestDetailsPage(user.RequestId));
        }
    }
}