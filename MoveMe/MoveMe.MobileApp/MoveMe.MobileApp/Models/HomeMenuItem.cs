namespace MoveMe.MobileApp.Models
{
    public enum MenuItemType
    {
        Dashboard,
        SupplierDashboard,
        MyOffers,
        NewRequest,
        Browse,
        About,
        AllSuppliers,
        Profile,
        LogOut,
        Notifications
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
