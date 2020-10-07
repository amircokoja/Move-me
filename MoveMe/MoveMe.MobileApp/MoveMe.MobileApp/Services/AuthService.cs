using Flurl.Http;
using MoveMe.MobileApp.Models;
using MoveMe.Model;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveMe.MobileApp.Services
{
    public class AuthService
    {
#if DEBUG
        public string _apiUrl = "http://localhost:5000/api/auth";
#endif
        public AuthService()
        {
        }
        public async Task<Login> Login(Model.Requests.LoginRequest request)
        {
            var fullUrl = _apiUrl + "/login";

            try
            {
                return await fullUrl.PostJsonAsync(request).ReceiveJson<Login>();
            }
            catch (FlurlHttpException ex)
            {
                var message = await GetErrorMessage(ex);

                await Application.Current.MainPage.DisplayAlert(Constants.Error, message, Constants.OK);
                throw;
            }
        }

        public async Task<User> Register(Model.Requests.RegisterRequest request)
        {
            var fullUrl = _apiUrl + "/register";

            try
            {
                return await fullUrl.PostJsonAsync(request).ReceiveJson<User>();
            }
            catch (FlurlHttpException ex)
            {
                var message = await GetErrorMessage(ex);

                await Application.Current.MainPage.DisplayAlert(Constants.Error, message, Constants.OK);
                throw;
            }
        }

        //public async Task<List<ComboBoxItem>> GetRoles()
        //{
        //    var fullUrl = _apiUrl + "/get-roles?includeAdmin=false";
        //    var result = await fullUrl.GetJsonAsync<List<ComboBoxItem>>();
        //    return result;
        //}

        public async Task<List<User>> GetAll(Model.Requests.UserSearchReqeust request)
        {
            var fullUrl = _apiUrl;
            if (request != null)
            {
                fullUrl += "?";
                fullUrl += await request.ToQueryString();
            }

            var result = await fullUrl.GetJsonAsync<List<User>>();
            return result;
        }

        private async Task<string> GetErrorMessage(FlurlHttpException ex)
        {
            string message = string.Empty;
            try
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                foreach (var error in errors)
                {
                    message = error.Value[0];
                }
            }
            catch (System.Exception)
            {
                message = Constants.UnknownError;
            }

            return message;
        }

        public async Task<User> GetById(int id)
        {
            var fullUrl = _apiUrl + "/" + id;
            return await fullUrl.GetJsonAsync<User>();
        }
    }
}
