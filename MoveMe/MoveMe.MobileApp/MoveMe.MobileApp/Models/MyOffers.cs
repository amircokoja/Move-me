using System;

namespace MoveMe.MobileApp.Models
{
    public class MyOffers
    {
        public int OfferId { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public string OfferStatus { get; set; }
        public int RequestId { get; set; }
        public bool IsActive { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsRejected { get; set; }
        public bool IsFinished { get; set; }
    }
}
