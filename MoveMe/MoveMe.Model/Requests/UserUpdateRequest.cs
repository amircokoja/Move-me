using System.ComponentModel.DataAnnotations;

namespace MoveMe.Model.Requests
{
    public class UserUpdateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public byte[] Image { get; set; }
    }
}