using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Services;

namespace MoveMe.WebAPI.Controllers
{
    public class RatingController : BaseCRUDController<Rating, RatingSearchRequest, RatingUpsertRequest, RatingUpsertRequest>
    {
        public RatingController(ICRUDService<Rating, RatingSearchRequest, RatingUpsertRequest, RatingUpsertRequest> service) : base(service)
        {
        }
    }
}
