using System;

namespace MoveMe.MobileApp.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int NotificationTypeId { get; set; }
        public int UserToId { get; set; }
    }
}
