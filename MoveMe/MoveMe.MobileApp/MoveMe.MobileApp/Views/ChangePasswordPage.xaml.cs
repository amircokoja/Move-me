using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage : ContentPage
    {
        ChangePasswordViewModel model = null;
        public ChangePasswordPage()
        {
            InitializeComponent();
            BindingContext = model = new ChangePasswordViewModel();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await model.ChangePassword();
        }
    }
}