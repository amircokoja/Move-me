using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Services;

namespace MoveMe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseCRUDController<Address, object, AddressUpsertRequest, AddressUpsertRequest>
    {
        public AddressController(ICRUDService<Address, object, AddressUpsertRequest, AddressUpsertRequest> service)
            :base (service)
        {

        }
    }
}
