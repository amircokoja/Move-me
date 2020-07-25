namespace MoveMe.Model
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string AdditionalAddress { get; set; }
        public int? CountryId { get; set; }
    }
}
