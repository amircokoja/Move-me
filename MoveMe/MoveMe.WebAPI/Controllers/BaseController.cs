using Microsoft.AspNetCore.Mvc;
using MoveMe.WebAPI.Services;
using System.Collections.Generic;

namespace MoveMe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TSearch> : ControllerBase
    {
        protected IService<T, TSearch> _service;

        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual IList<T> GetAll([FromQuery] TSearch request = default)
        {
            return _service.GetAll(request);
        }

        [HttpGet("{id}")]
        public virtual T GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
