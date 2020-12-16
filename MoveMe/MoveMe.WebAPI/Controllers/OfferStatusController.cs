using MoveMe.Model;
using MoveMe.WebAPI.Services;

namespace MoveMe.WebAPI.Controllers
{
    public class OfferStatusController : BaseController<OfferStatus, object>
    {
        public OfferStatusController(IService<OfferStatus, object> service) : base(service)
        {
        }
    }
}
