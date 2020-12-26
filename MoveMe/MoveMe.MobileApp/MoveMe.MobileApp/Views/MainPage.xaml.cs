using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using MoveMe.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveMe.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;
            MenuPages.Add((int)MenuItemType.Notifications, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.NewRequest:
                        MenuPages.Add(id, new NavigationPage(new NewRequestPage(null)));
                        break;
                    case (int)MenuItemType.SupplierDashboard:
                        MenuPages.Add(id, new NavigationPage(new SupplierDashboardPage()));
                        break;
                    case (int)MenuItemType.Dashboard:
                        MenuPages.Add(id, new NavigationPage(new DashboardPage()));
                        break;
                    case (int)MenuItemType.AllSuppliers:
                        MenuPages.Add(id, new NavigationPage(new AllSuppliersPage()));
                        break;
                    case (int)MenuItemType.Notifications:
                        MenuPages.Add(id, new NavigationPage(new NotificationsPage()));
                        break;
                    case (int)MenuItemType.MyOffers:
                        MenuPages.Add(id, new NavigationPage(new MyOffersPage()));
                        break;
                    case (int)MenuItemType.Profile:
                        MenuPages.Add(id, new NavigationPage(new ProfilePage()));
                        break;
                    case (int)MenuItemType.LogOut:
                        MenuPages.Add(id, new NavigationPage(new LogOutPage()));
                        break;
                    case (int)MenuItemType.AllRequests:
                        MenuPages.Add(id, new NavigationPage(new SupplierAllRequestsPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;
                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}