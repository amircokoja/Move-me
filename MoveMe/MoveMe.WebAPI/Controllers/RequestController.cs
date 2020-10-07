using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Services;

namespace MoveMe.WebAPI.Controllers
{
    public class RequestController : BaseCRUDController<Request, RequestSearchRequest, RequestInsertRequest, RequestUpdateRequest>
    {
        public RequestController(ICRUDService<Request, RequestSearchRequest, RequestInsertRequest, RequestUpdateRequest> service) : base(service)
        {
        }
    }
}
