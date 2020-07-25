using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MoveMe.WebAPI.Database
{
    public partial class User : IdentityUser<int>
    {
        public User()
        {
            Request = new HashSet<Request>();
        }

        public int UserId { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AddressId { get; set; }
        public byte[] Image { get; set; }
        public bool Active { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Request> Request { get; set; }
    }
}
