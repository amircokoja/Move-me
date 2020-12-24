namespace MoveMe.Model
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
    }

    public enum EStatus
    {
        Pending = 1,
        Accepted,
        Finished
    }
}
