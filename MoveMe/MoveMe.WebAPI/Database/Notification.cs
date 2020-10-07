using System;

namespace MoveMe.WebAPI.Database
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserToId { get; set; }
        public int UserFromId { get; set; }
        public int NotificationTypeId { get; set; }
        public virtual User UserTo { get; set; }
        public virtual User UserFrom { get; set; }
        public virtual NotificationType NotificationType { get; set; }
    }
}
