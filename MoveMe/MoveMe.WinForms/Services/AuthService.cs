using MoveMe.WinForms.Properties;
using System.Threading.Tasks;
using Flurl.Http;
using System.Collections.Generic;
using MoveMe.Model;
using System.Windows.Forms;

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

            try
            {
                return await fullUrl.PostJsonAsync(request).ReceiveJson<dynamic>();
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseJsonAsync<ErrorModel>();
                string text;
                if (error == null)
                {
                    text = "Unknown error occurred.";
                }
                else if (error.ERROR == null)
                {
                    text = "Please enter valid credentials";
                }
                else
                {
                    text = error.ERROR[0];
                }
                throw new System.Exception(text);
            }
        }

        public async Task<User> ChangePassword(int id, Model.Requests.PasswordChangeRequest request)
        {
            var fullUrl = apiUrl + "/changepassword/" + id;
            try
            {
                return await fullUrl.PostJsonAsync(request).ReceiveJson<User>();
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseJsonAsync<ErrorModel>();
                string text;
                if (error.ERROR != null)
                {
                    text = error.ERROR[0];
                }
                else
                {
                    text = "Unknown error ocurred";
                }

                throw new System.Exception(text);
            }
        }

        public async Task<User> Register(Model.Requests.RegisterRequest request)
        {
            var fullUrl = apiUrl + "/register";
            try
            {
                return await fullUrl.PostJsonAsync(request).ReceiveJson<User>();
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseJsonAsync<ErrorModel>();
                var text = error.ERROR[0];
                MessageBox.Show(text, "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw ex;
            }
        }

        public async Task<User> Update(int UserId, Model.Requests.UserUpdateRequest request)
        {
            var fullUrl = apiUrl + "/" + UserId;
            try
            {
                return await fullUrl.PutJsonAsync(request).ReceiveJson<User>();
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseJsonAsync<ErrorModel>();
                throw ex;
            }
        }
        public async Task<User> GetById(int UserId)
        {
            var fullUrl = apiUrl + "/" + UserId;
            var result = await fullUrl.GetJsonAsync<User>();
            return result;
        }

        public async Task<DashboardCounters> GetCounters()
        {
            var fullUrl = apiUrl + "/get-counters";
            var result = await fullUrl.GetJsonAsync<DashboardCounters>();
            return result;
        }

        public async Task<User> Deactivate(int UserId)
        {
            var fullUrl = apiUrl + "/deactivate/" + UserId;
            var result = await fullUrl.GetJsonAsync<User>();
            return result;
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

        public async Task<RoleModel> GetRole(int UserId)
        {
            var fullUrl = apiUrl + "/get-role/" + UserId;

            return await fullUrl.GetJsonAsync<RoleModel>();
        }
    }
}
