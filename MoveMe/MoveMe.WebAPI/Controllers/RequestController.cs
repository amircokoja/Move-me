using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Services;
using System.Collections.Generic;

namespace MoveMe.WebAPI.Controllers
{
    public class RequestController : BaseCRUDController<Request, RequestSearchRequest, RequestInsertRequest, RequestUpdateRequest>
    {
        public RequestController(ICRUDService<Request, RequestSearchRequest, RequestInsertRequest, RequestUpdateRequest> service) : base(service)
        {
        }

        [AllowAnonymous]
        [HttpGet("recommend/{id}")]
        public List<Request> Recommend(int id)
        {
            return (_service as IRequestService).Recommend(id);
        }
    }
}
