using System;
using System.ComponentModel.DataAnnotations;

namespace MoveMe.Model.Requests
{
    public class NotificationInsertRequest
    {
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public int UserToId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int UserFromId { get; set; }
        [Required]
        public int NotificationTypeId { get; set; }
    }
}
