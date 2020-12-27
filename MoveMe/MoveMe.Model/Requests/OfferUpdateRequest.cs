using System.ComponentModel.DataAnnotations;

namespace MoveMe.Model.Requests
{
    public class OfferUpdateRequest
    {
        [Required]
        public int OfferStatusId { get; set; }
    }
}
