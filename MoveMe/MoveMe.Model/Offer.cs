using System;

namespace MoveMe.Model
{
    public class Offer
    {
        public int OfferId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int OfferStatusId { get; set; }
    }
}
