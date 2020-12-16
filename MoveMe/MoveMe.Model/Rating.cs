namespace MoveMe.Model
{
    public class Rating
    {
        public int RatingId { get; set; }
        public string Description { get; set; }
        public int? RequestId { get; set; }
        public int? RatingTypeId { get; set; }
        public int? SupplierId { get; set; }
    }
}
