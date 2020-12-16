using System;

namespace MoveMe.Model.Requests
{
    public class RequestSearchRequest
    {
        public int? UserId { get; set; }
        public double? MinimumPrice { get; set; }
        public int? MaximumRooms { get; set; }
        public int? CountryId { get; set; }
        public int? StatusId { get; set; }
        public bool? ShowInactive { get; set; }
    }
}
