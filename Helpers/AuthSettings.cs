using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PetProject.Helpers
{
    internal static class AuthSettings
    {
        public const string ISSUER = "PetProjectDevelop";
        public const string AUDIENCE = "VueClientApp";
        const string KEY = "vKORICWIitOfb6NgBulcNzeDDSdymbZg|WnFbVQ/hTtxazVF/s7fCWYgb2jSWjAyR";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}