using System;

namespace MoveMe.MobileApp.Models
{
    public class UserRating
    {
        public int RatingId { get; set; }
        public string UserFrom { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public int RatingTypeId { get; set; }
    }
}
