namespace MoveMe.MobileApp.Models
{
    public enum MenuItemType
    {
        SupplierDashboard,
        Dashboard,
        MyOffers,
        NewRequest,
        Browse,
        About,
        AllSuppliers,
        Profile,
        LogOut,
        Notifications,
        AllRequests
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
