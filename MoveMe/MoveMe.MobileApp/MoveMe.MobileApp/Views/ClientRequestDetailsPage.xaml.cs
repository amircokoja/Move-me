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
    public partial class ClientRequestDetailsPage : ContentPage
    {
        ClientRequestDetailsViewModel model = null;
        public ClientRequestDetailsPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new ClientRequestDetailsViewModel();
            model.Id = id;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}