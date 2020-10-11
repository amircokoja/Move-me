using System;
using System.Collections.Generic;

namespace MoveMe.WebAPI.Database
{
    public partial class Request
    {
        public Request()
        {
            Rating = new HashSet<Rating>();
        }

        public int RequestId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime Created { get; set; }
        public double? Price { get; set; }
        public int? Rooms { get; set; }
        public int? TotalWeightApprox { get; set; }
        public string AdditionalInformation { get; set; }
        public int? ClientId { get; set; }
        public int? DeliveryAddress { get; set; }
        public int? StatusId { get; set; }
        public int TransportDistanceApprox { get; set; }
        public virtual User Client { get; set; }
        public virtual Address DeliveryAddressNavigation { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
