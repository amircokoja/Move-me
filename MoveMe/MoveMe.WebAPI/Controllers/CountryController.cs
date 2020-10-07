using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Services;
using System.Collections.Generic;

namespace MoveMe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountryController : BaseCRUDController<Country, object, CountryUpsertRequest, CountryUpsertRequest>
    {
        public CountryController(ICRUDService<Country, object, CountryUpsertRequest, CountryUpsertRequest> service)
            :base (service)
        {
        }
        [AllowAnonymous]
        public override IList<Country> GetAll([FromQuery] object request = null)
        {
            return base.GetAll(request);
        }
    }
}
