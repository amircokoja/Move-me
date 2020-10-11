using MoveMe.MobileApp.Models;
using MoveMe.MobileApp.Services;
using MoveMe.MobileApp.ViewModels;
using MoveMe.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoveMe.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        MenuViewModel vm = null;
        public event EventHandler<object> masterViewEventHandler;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>();

            if (APIService.roleId == (int)RoleId.Client)
            {
                menuItems.Add(new HomeMenuItem { Id = MenuItemType.Dashboard, Title = "Dashboard" });
                menuItems.Add(new HomeMenuItem { Id = MenuItemType.Notifications, Title = "Notifications" });
                menuItems.Add(new HomeMenuItem { Id = MenuItemType.NewRequest, Title = "New request" });
                menuItems.Add(new HomeMenuItem { Id = MenuItemType.AllSuppliers, Title = "All suppliers" });
            }
            else
            {
                menuItems.Add(new HomeMenuItem { Id = MenuItemType.SupplierDashboard, Title = "Dashboard" });
                menuItems.Add(new HomeMenuItem { Id = MenuItemType.Notifications, Title = "Notifications" });
                menuItems.Add(new HomeMenuItem { Id = MenuItemType.MyOffers, Title = "My offers" });

            }
            menuItems.Add(new HomeMenuItem { Id = MenuItemType.Profile, Title = "Profile" });
            menuItems.Add(new HomeMenuItem { Id = MenuItemType.LogOut, Title = "Log out" });
          

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }

        private void MenuItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            masterViewEventHandler?.Invoke(this, vm.SelectedMenuItem);
        }
        public void SetPropertySelected()
        {
            vm.SelectedMenuItem = "";
        }
    }
}