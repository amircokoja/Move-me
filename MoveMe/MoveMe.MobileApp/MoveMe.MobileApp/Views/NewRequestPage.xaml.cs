
using MoveMe.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRequestPage : ContentPage
    {
        NewRequestViewModel model = null;
        public NewRequestPage()
        {
            InitializeComponent();
            BindingContext = model = new NewRequestViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}