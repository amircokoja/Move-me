using MoveMe.WinForms.Properties;
using System.Threading.Tasks;
using Flurl.Http;
using MoveMe.Model;

namespace MoveMe.WinForms.Services
{
    public class APIService
    {
        public static string token { get; set; }
        public string apiUrl = null;

        public APIService(string route)
        {
            apiUrl = $"{Resources.apiUrl}/{route}";
        }

        public async Task<T> GetAll<T>(object searchRequest = null)
        {
            var query = "";
            if (searchRequest != null)
            {
                query = await searchRequest?.ToQueryString();
            }

            var result = await $"{apiUrl}?{query}".WithOAuthBearerToken(token).GetJsonAsync<T>();

            return result;
        }

        public async Task<T> GetById<T>(int id)
        {
            var url = apiUrl + "/" + id;
            var result = await url.WithOAuthBearerToken(token).GetJsonAsync<T>();
            return result;
        }

        public async Task<T> Update<T>(int id, object request)
        {
            var url = apiUrl + "/" + id;
            var result = await url.WithOAuthBearerToken(token).PutJsonAsync(request).ReceiveJson<T>();
            return result;
        }
    }
}
