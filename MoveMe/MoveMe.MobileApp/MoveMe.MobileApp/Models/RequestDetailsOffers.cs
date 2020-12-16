using System;

namespace MoveMe.MobileApp.Models
{
    public class RequestDetailsOffers
    {
        public int OfferId { get; set; }
        public int UserFromId { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
    }
}
