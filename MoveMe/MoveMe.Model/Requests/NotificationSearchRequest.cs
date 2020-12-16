using System;

namespace MoveMe.Model.Requests
{
    public class NotificationSearchRequest
    {
        public int? UserToId { get; set; }
        public int? UserFromId { get; set; }
        public int? NotificationTypeId { get; set; }
        public int? ItemId{ get; set; }
    }
}
