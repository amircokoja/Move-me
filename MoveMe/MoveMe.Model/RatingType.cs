namespace MoveMe.Model
{
    public class RatingType
    {
        public int RatingTypeId { get; set; }
        public string Type { get; set; }
    }

    public enum ERatingType
    {
        Positive = 1,
        Neutral,
        Negative
    }
}
