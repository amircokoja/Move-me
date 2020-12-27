using System;
using System.ComponentModel.DataAnnotations;

namespace MoveMe.Model.Requests
{
    public class RegisterRequest
    {
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public byte[] Image { get; set; }
        public string AdditionalAddress { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
