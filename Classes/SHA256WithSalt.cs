using System;
using System.Security.Cryptography;
using System.Text;

namespace WellnessNavigator1.Classes
{
    public class SHA256WithSaltAlgorithm : Algorithms
    {
        private const int SaltSize = 16;

        public override string ComputeHash(string password)
        {
            // Generate a random salt
            byte[] saltBytes = new byte[SaltSize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            // Combine the input and salt
            byte[] combinedBytes = Encoding.UTF8.GetBytes(password + Convert.ToBase64String(saltBytes));

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public override string ComputeHash(string password, byte[] salt)
        {
            // Combine the input and salt
            byte[] combinedBytes = Encoding.UTF8.GetBytes(password + Convert.ToBase64String(salt));

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
