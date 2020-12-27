using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoveMe.Model;
using MoveMe.WebAPI.Services;
using System.Collections.Generic;

namespace MoveMe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountryController : BaseController<Country, object>
    {
        public CountryController(IService<Country, object> service)
            :base (service)
        {}

        [AllowAnonymous]
        public override IList<Country> GetAll([FromQuery] object request = null)
        {
            return base.GetAll(request);
        }
    }
}
