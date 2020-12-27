using System;
using System.ComponentModel.DataAnnotations;

namespace MoveMe.Model.Requests
{
    public class OfferInsertRequest
    {
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public int RequestId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int OfferStatusId { get; set; }
    }
}
