using Flurl.Http;
using MoveMe.MobileApp.Models;
using MoveMe.Model;
using MoveMe.Model.Requests;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveMe.MobileApp.Services
{
    public class AuthService
    {
#if DEBUG
        public string _apiUrl = "http://localhost:51886/api/auth";
#endif
        public AuthService()
        {
        }
        public async Task<Login> Login(LoginRequest request)
        {
            var fullUrl = _apiUrl + "/login";

            try
            {
                var result = await fullUrl.PostJsonAsync(request).ReceiveJson<Login>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                var message = await GetErrorMessage(ex);
                await Application.Current.MainPage.DisplayAlert(Constants.Error, message, Constants.OK);
                throw new System.Exception(message);
            }
        }

        public async Task<User> Register(RegisterRequest request)
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

        public async Task<List<User>> GetAll(UserSearchReqeust request)
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

        public async Task<User> Update(int id, UserUpdateRequest request)
        {
            var fullUrl = _apiUrl + "/" + id;

            try
            {
                var result = await fullUrl.PutJsonAsync(request).ReceiveJson<User>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                var error = await GetErrorMessage(ex);
                await Application.Current.MainPage.DisplayAlert(Constants.Error, error, Constants.OK);
                return default(User);
            }
        }
        
        public async Task<User> ChangePassword(int id, PasswordChangeRequest request)
        {
            var fullUrl = _apiUrl + "/changepassword/" + id;
            try
            {
                var result = await fullUrl.PostJsonAsync(request).ReceiveJson<User>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                var message = await GetErrorMessage(ex);

                await Application.Current.MainPage.DisplayAlert(Constants.Error, message, Constants.OK);
                throw;
            }
        }
    }
}
