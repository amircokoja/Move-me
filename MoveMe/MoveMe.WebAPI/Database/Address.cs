using System;
using System.Collections.Generic;

namespace MoveMe.WebAPI.Database
{
    public partial class Address
    {
        public Address()
        {
            Request = new HashSet<Request>();
            User = new HashSet<User>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string AdditionalAddress { get; set; }
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
