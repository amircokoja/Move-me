using MoveMe.WinForms.Properties;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

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

        public async Task<T> GetAll<T>()
        {
            var result = await apiUrl.WithOAuthBearerToken(token).GetJsonAsync<T>();

            return result;
        }
    }
}
