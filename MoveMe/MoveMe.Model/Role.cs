namespace MoveMe.Model
{
    public static class Role
    {
        public static string Admin = "Admin";
        public static string Client = "Client";
        public static string Supplier = "Supplier";
    }

    public enum RoleId
    {
        Admin = 1,
        Client,
        Supplier
    }
    public class RoleModel
    {
        public string Role { get; set; }
    }
}
