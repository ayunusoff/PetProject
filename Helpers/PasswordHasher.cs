using System.Security.Cryptography;

namespace PetProject.Helpers
{
    public class PasswordHasher
    {
        public static string GenerateSalt(int nSalt)
        {
            var saltBytes = new byte[nSalt];
            string refreshToken = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
                refreshToken = Convert.ToBase64String(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt, int nIterations = 1000, int nHash = 24)
        {
            var saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                string passHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash)) + "|" + Convert.ToBase64String(rfc2898DeriveBytes.Salt);

                return passHash;
            }
        }
    }
}
