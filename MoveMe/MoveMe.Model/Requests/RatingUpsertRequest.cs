namespace MoveMe.Model.Requests
{
    public class RatingUpsertRequest
    {
        public string Description { get; set; }
        public int RequestId { get; set; }
        public int RatingTypeId { get; set; }
        public int SupplierId { get; set; }
    }
}