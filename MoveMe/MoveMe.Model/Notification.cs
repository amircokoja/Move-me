using System;

namespace MoveMe.Model
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserToId { get; set; }
        public int ItemId { get; set; }
        public int UserFromId { get; set; }
        public int NotificationTypeId { get; set; }
    }
}
