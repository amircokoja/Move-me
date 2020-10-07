using MoveMe.Model;
using MoveMe.WebAPI.Services;

namespace MoveMe.WebAPI.Controllers
{
    public class StatusController : BaseController<Status, object>
    {
        public StatusController(IService<Status, object> service) : base(service)
        {
        }
    }
}
