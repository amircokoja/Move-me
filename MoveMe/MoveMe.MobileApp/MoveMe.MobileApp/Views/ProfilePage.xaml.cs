using MoveMe.MobileApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var profilePage = e.SelectedItem as ProfileOptions;

            switch ((int)profilePage.Value)
            {
                case (int)ProfileOptionsValue.BasicInformation:
                    await Navigation.PushAsync(new BasicInformationPage());
                    break;
                case (int)ProfileOptionsValue.Address:
                    await Navigation.PushAsync(new AddressPage());
                    break;
                case (int)ProfileOptionsValue.Password:
                    await Navigation.PushAsync(new ChangePasswordPage());
                    break;
                default:
                    break;
            }
        }
    }
}