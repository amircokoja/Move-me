using Microsoft.Extensions.Configuration;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;

namespace MoveMe.WinUI
{
    public class APIService
    {
        public static string _token { get; set; }

        private string _apiUrl = null;
        public APIService(string route)
        {
           var configuration = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            _apiUrl = $"{configuration["APIUrl"]}/route";
        }

        public async Task<T> GetAll<T>()
        {
            var result = await _apiUrl.WithOAuthBearerToken(_token).GetJsonAsync<T>();

            return result;
        }
    }
}
