using System.ComponentModel.DataAnnotations;

namespace MoveMe.Model.Requests
{
    public class RatingUpsertRequest
    {
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public int RequestId { get; set; }
        [Required]
        public int RatingTypeId { get; set; }
        [Required]
        public int SupplierId { get; set; }
    }
}