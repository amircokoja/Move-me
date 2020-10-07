using MoveMe.MobileApp.ViewModels;
using MoveMe.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientAllSuppliersPage : ContentPage
    {
        ClientAllSuppliersViewModel model = null;
        public ClientAllSuppliersPage()
        {
            InitializeComponent();
            BindingContext = model = new ClientAllSuppliersViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (model != null)
            {
                await model.Init();
            }
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var user = e.SelectedItem as User;

            await Navigation.PushAsync(new ClientSupplierDetailsPage(user.Id));
        }
    }
}