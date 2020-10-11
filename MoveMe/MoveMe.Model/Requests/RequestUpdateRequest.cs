using System;

namespace MoveMe.Model.Requests
{
    public class RequestUpdateRequest
    {
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public int Rooms { get; set; }
        public int TotalWeightApprox { get; set; }
        public int TransportDistanceApprox { get; set; }
        public string AdditionalInformation { get; set; }
        public int StatusId { get; set; }
    }
}
