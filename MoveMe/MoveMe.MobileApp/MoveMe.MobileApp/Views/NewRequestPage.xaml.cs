
using MoveMe.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRequestPage : ContentPage
    {
        NewRequestViewModel model = null;

        public NewRequestPage(int? RequestId)
        {
            InitializeComponent();
            BindingContext = model = new NewRequestViewModel();
            model.RequestId = RequestId;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private void Entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (model != null)
            {
                model.CheckPriceValidity();
            }
        }
    }
}