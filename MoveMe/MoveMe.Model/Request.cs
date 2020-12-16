using System;

namespace MoveMe.Model
{
    public class Request
    {
        public int RequestId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Created { get; set; }
        public double Price { get; set; }
        public int Rooms { get; set; }
        public int TotalWeightApprox { get; set; }
        public string AdditionalInformation { get; set; }
        public int TransportDistanceApprox { get; set; }
        public int ClientId { get; set; }
        public int DeliveryAddress { get; set; }
        public int StatusId { get; set; }
        public bool Inactive { get; set; }
    }
}
