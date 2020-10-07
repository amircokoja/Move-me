namespace MoveMe.Model.Requests
{
    public class UserSearchReqeust
    {
        public string Name { get; set; }
        public int? RoleId { get; set; }
        public bool ShowInactive { get; set; }
        public string Company { get; set; }
    }
}