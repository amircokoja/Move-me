namespace MoveMe.Model
{
    public class OfferStatus
    {
        public int OfferStatusId { get; set; }
        public string Name { get; set; }
    }

    public enum EOfferStatus
    {
        Active = 1,
        Accepted,
        Rejected,
        Finished
    }
}
