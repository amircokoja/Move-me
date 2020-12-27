using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.ViewModels;
using System.Text.RegularExpressions;
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
            var request = e.SelectedItem as RequestModel;

            await Navigation.PushAsync(new RequestDetailsPage(request.RequestId));
        }

        private void Entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (model != null && model.MinimumPrice.Length != 0)
            {
                if (Regex.IsMatch(model.MinimumPrice, "[^0-9]"))
                {
                    model.MinimumPrice = model.MinimumPrice.Remove(model.MinimumPrice.Length - 1);
                }
            }
        }

        private void Entry_PropertyChanged_1(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (model != null && model.MaximumRooms.Length != 0)
            {
                if (Regex.IsMatch(model.MaximumRooms, "[^0-9]"))
                {
                    model.MaximumRooms = model.MaximumRooms.Remove(model.MaximumRooms.Length - 1);
                }
            }
        }
    }
}