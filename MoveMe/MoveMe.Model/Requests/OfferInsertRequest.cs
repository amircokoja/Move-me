using System;

namespace MoveMe.Model.Requests
{
    public class OfferInsertRequest
    {
        public DateTime CreatedAt { get; set; }
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public int OfferStatusId { get; set; }
    }
}
