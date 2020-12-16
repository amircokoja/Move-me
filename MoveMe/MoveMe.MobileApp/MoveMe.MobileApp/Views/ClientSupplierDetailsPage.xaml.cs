using MoveMe.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientSupplierDetailsPage : ContentPage
    {

        ClientSupplierDetailsViewModel model = null;
        public ClientSupplierDetailsPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new ClientSupplierDetailsViewModel();
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