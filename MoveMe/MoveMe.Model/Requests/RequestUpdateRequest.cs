using System;
using System.ComponentModel.DataAnnotations;

namespace MoveMe.Model.Requests
{
    public class RequestUpdateRequest
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Rooms { get; set; }
        [Required]
        public int TotalWeightApprox { get; set; }
        [Required]
        public int TransportDistanceApprox { get; set; }
        public string AdditionalInformation { get; set; }
        [Required]
        public int StatusId { get; set; }
        public bool InActive { get; set; }
    }
}
