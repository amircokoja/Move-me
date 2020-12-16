using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Services;

namespace MoveMe.WebAPI.Controllers
{
    public class OfferController : BaseCRUDController<Offer, OfferSearchRequest, OfferInsertRequest, OfferUpdateRequest>
    {
        public OfferController(ICRUDService<Offer, OfferSearchRequest, OfferInsertRequest, OfferUpdateRequest> service) : base(service)
        {
        }
    }
}
