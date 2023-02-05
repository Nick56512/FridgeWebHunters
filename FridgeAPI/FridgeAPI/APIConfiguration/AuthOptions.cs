using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FridgeOfWebHunter.APIConfiguration
{
    public class AuthOptions
    {
        public const string ISSUER = "WEBHUNTERS";
        public const string AUDIENCE = "INT20T";
        const string KEY = "APISECRETSECURITYKEY";
        public const int LIFETIME = 20;
        public static SymmetricSecurityKey GetSymetricKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
