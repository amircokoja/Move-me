using MoveMe.Model;
using MoveMe.WebAPI.Services;

namespace MoveMe.WebAPI.Controllers
{
    public class RatingTypeController : BaseController<RatingType, object>
    {
        public RatingTypeController(IService<RatingType, object> service) : base(service)
        {
        }
    }
}
