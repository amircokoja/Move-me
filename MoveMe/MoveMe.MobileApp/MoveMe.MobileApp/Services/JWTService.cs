using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MoveMe.MobileApp.Services
{
    public class JWTService
    {
        public static string DecodeJWT()
        {
            try
            {
                var token = APIService.token;
                var handler = new JwtSecurityTokenHandler();
                var data = handler.ReadJwtToken(token);

                foreach (var claim in data.Claims)
                {
                    if (claim.Type == "UserID")
                    {
                        return claim.Value;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static string DecodeJWTRole()
        {
            try
            {
                var token = APIService.token;
                var handler = new JwtSecurityTokenHandler();
                var data = handler.ReadJwtToken(token);

                foreach (var claim in data.Claims)
                {
                    if (claim.Type == "Role")
                    {
                        return claim.Value;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}
