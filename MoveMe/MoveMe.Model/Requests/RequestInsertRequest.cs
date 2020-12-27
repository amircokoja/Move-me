using System;
using System.ComponentModel.DataAnnotations;

namespace MoveMe.Model.Requests
{
    public class RequestInsertRequest
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Rooms { get; set; }
        [Required]
        public int TotalWeightApprox { get; set; }
        public string AdditionalInformation { get; set; }
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int DeliveryAddress { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public int TransportDistanceApprox { get; set; }
    }
}
