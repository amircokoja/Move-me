using MoveMe.MobileApp.Services;
using MoveMe.MobileApp.Views;
using Xamarin.Forms;
[assembly: ExportFont("WorkSans.ttf")]

namespace MoveMe.MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
