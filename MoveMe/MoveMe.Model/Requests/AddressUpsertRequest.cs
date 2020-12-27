using System.ComponentModel.DataAnnotations;

namespace MoveMe.Model.Requests
{
    public class AddressUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        [MaxLength(40)]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        [MaxLength(10)]
        public string ZipCode { get; set; }
        [MaxLength(60)]
        public string AdditionalAddress { get; set; }
        public int CountryId { get; set; }
    }
}
