using MoveMe.WinForms.Properties;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using MoveMe.Model;
using System.Threading;

namespace MoveMe.WinForms.Services
{
    public class AuthService
    {
        private string apiUrl = $"{Resources.apiUrl}/auth";


        public AuthService()
        {

        }
        public async Task<dynamic> Login(Model.Requests.LoginRequest request)
        {
            var fullUrl = apiUrl + "/login";

            return await fullUrl.PostJsonAsync(request).ReceiveJson<dynamic>();
        }

        public async Task<User> Register(Model.Requests.RegisterRequest request)
        {
            var fullUrl = apiUrl + "/register";
            return await fullUrl.PostJsonAsync(request).ReceiveJson<User>();
        }

        public async Task<List<ComboBoxItem>> GetRoles()
        {
            var fullUrl = apiUrl + "/get-roles?includeAdmin=false";
            var result = await fullUrl.GetJsonAsync<List<ComboBoxItem>>();
            return result;
        }

        public async Task<List<User>> GetUsers(Model.Requests.UserSearchReqeust request)
        {
            var fullUrl = apiUrl;
            if (request != null)
            {
                fullUrl += "?";
                fullUrl += await request.ToQueryString();
            }

            var result = await fullUrl.GetJsonAsync<List<User>>();
            return result;
        }
    }
}
