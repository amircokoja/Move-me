namespace MoveMe.MobileApp.Models
{
    public enum MenuItemType
    {
        Dashboard,
        NewRequest,
        Browse,
        About,
        AllSuppliers
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
