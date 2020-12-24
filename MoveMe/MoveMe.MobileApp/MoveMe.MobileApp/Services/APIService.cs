using Flurl.Http;
using MoveMe.MobileApp.Models;
using MoveMe.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoveMe.MobileApp.Services
{
    public class APIService
    {
        public static string token { get; set; }
        public static int roleId { get; set; }
        public string url = null;

#if DEBUG
        public string _apiUrl = "http://localhost:5000/api";
#endif

        public APIService(string route)
        {
            url = $"{_apiUrl}/{route}";
        }

        public async Task<T> GetAll<T>(object search = null)
        {
            var fullUrl = url;
            try
            {
                if (search != null)
                {
                    fullUrl += "?";
                    fullUrl += await search.ToQueryString();
                }

                return await fullUrl.WithOAuthBearerToken(token).GetJsonAsync<T>();

            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Not authorized", "Ok");
                }
                throw;
            }
        }

        public async Task<T> Insert<T>(object request)
        {
            try
            {
                return await url.WithOAuthBearerToken(token).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var error = await GetErrorMessage(ex);

                await Application.Current.MainPage.DisplayAlert(Constants.Error, error, Constants.OK);
                return default(T);
            }
        }

        private async Task<string> GetErrorMessage(FlurlHttpException ex)
        {
            var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

            var message = string.Empty;
            foreach (var error in errors)
            {
                message = error.Value[0];
            }

            return message;
        }

        public async Task<T> GetById<T>(int id)
        {
            var fullUrl = url + "/" + id;
            return await fullUrl.WithOAuthBearerToken(token).GetJsonAsync<T>();
        }

        public async Task<T> RecommendRequest<T>(int RequestId)
        {
            var fullUrl = url + "/recommend/" + RequestId;
            return await fullUrl.WithOAuthBearerToken(token).GetJsonAsync<T>();
        }

        public async Task<T> Update<T>(int id, object request)
        {
            var fullUrl = url + "/" + id;

            try
            {
                var result = await fullUrl.WithOAuthBearerToken(token).PutJsonAsync(request).ReceiveJson<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                var error = await GetErrorMessage(ex);
                await Application.Current.MainPage.DisplayAlert(Constants.Error, error, Constants.OK);
                return default(T);
            }
        }

        public async Task Delete(int id)
        {
            var fullUrl = url + "/" + id;
            await fullUrl.WithOAuthBearerToken(token).DeleteAsync();
        }
    }
}
