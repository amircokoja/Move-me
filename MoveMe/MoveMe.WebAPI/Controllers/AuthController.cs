using Microsoft.AspNetCore.Mvc;
using MoveMe.Model;
using MoveMe.Model.Requests;
using MoveMe.WebAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoveMe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<Login> Login(LoginRequest request)
        {
            return await _authService.Login(request);
        }

        [HttpPost("register")]
        public async Task<User> Register(RegisterRequest request)
        {
            return await _authService.Register(request);
        }

        [HttpGet]
        public async Task<List<User>> GetAll([FromQuery] UserSearchReqeust request)
        {
            return await _authService.GetAll(request);
        }

        [HttpGet("get-roles")]
        public async Task<List<ComboBoxItem>> GetRoles(bool includeAdmin = true)
        {
            return await _authService.GetRoles(includeAdmin);
        }

        [HttpGet("get-role/{id}")]
        public async Task<RoleModel> GetRole(int id)
        {
            return await _authService.GetRole(id);
        }

        [HttpGet("get-counters")]
        public async Task<DashboardCounters> GetCounters()
        {
            return await _authService.GetCounters();
        }

        [HttpPost("craete-role")]
        public async Task CreateRole(string role)
        {
            await _authService.CreateRole(role);
        }

        [HttpGet("{id}")]
        public async Task<User> GetById(int id)
        {
            return await _authService.GetById(id);
        }

        [HttpGet("deactivate/{id}")]
        public async Task<User> Deactivate(int id)
        {
            return await _authService.Deactivate(id);
        }

        [HttpPut("{id}")]
        public async Task<User> Update(int id, UserUpdateRequest request)
        {
            return await _authService.Update(id, request);
        }

        [HttpPost("changepassword/{id}")]
        public async Task<User> ChangePassword(int id, [FromBody] PasswordChangeRequest request)
        {
            return await _authService.ChangePassword(id, request);
        }
    }
}
