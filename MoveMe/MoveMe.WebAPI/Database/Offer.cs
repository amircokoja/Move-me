using System;

namespace MoveMe.WebAPI.Database
{
    public partial class Offer
    {
        public int OfferId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int OfferStatusId { get; set; }
        public virtual Request Request { get; set; }
        public virtual User User { get; set; }
        public virtual OfferStatus OfferStatus { get; set; }
    }
}
