using MoveMe.MobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackPage : ContentPage
    {
        FeedbackViewModel model = null;

        public FeedbackPage(int id)
        {
            InitializeComponent();
            BindingContext = model = new FeedbackViewModel();
            model.UserId = id;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}