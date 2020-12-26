using MoveMe.MobileApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupplierDetailsPage : ContentPage
    {

        SupplierDetailsViewModel model = null;
        public SupplierDetailsPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new SupplierDetailsViewModel();
            model.Id = id;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FeedbackPage(model.Id));
        }
    }
}