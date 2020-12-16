using System;

namespace MoveMe.Model.Requests
{
    public class NotificationInsertRequest
    {
        public DateTime CreatedAt { get; set; }
        public int UserToId { get; set; }
        public int ItemId { get; set; }
        public int UserFromId { get; set; }
        public int NotificationTypeId { get; set; }
    }
}
