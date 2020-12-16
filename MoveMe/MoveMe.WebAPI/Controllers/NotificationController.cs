using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Services;

namespace MoveMe.WebAPI.Controllers
{
    public class NotificationController : BaseCRUDController<Notification, NotificationSearchRequest, NotificationInsertRequest, NotificationUpdateRequest>
    {
        public NotificationController(ICRUDService<Notification, NotificationSearchRequest, NotificationInsertRequest, NotificationUpdateRequest> service) : base(service)
        {
        }
    }
}
