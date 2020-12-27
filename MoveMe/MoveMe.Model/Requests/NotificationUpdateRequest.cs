using System.ComponentModel.DataAnnotations;

namespace MoveMe.Model.Requests
{
    public class NotificationUpdateRequest
    {
        [Required]
        public int NotificationTypeId { get; set; }
    }
}
