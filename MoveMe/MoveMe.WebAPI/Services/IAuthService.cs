using MoveMe.Model;
using MoveMe.Model.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoveMe.WebAPI.Services
{
    public interface IAuthService
    {
        Task<Login> Login(LoginRequest request);
        Task<User> Register(RegisterRequest request);
        Task<List<User>> GetAll(UserSearchReqeust request);
        Task<List<ComboBoxItem>> GetRoles(bool includeAdmin = true);
        Task<RoleModel> GetRole(int id);
        Task<DashboardCounters> GetCounters();
        Task CreateRole(string role);
        Task<User> GetById(int id);
        Task<User> Deactivate(int id);
        Task<User> Update(int id, UserUpdateRequest request);
        Task<User> ChangePassword(int id, PasswordChangeRequest request);
    }
}
