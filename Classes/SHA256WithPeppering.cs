using System.Security.Cryptography;
using System.Text;

namespace WellnessNavigator1.Classes
{
    public class SHA256WithPepperingAlgorithm : Algorithms
    {
        private const string PepperingValue = "PepperIsSpicy";

        public override string ComputeHash(string input)
        {
            // Combine the input and pepper
            byte[] combinedBytes = Encoding.UTF8.GetBytes(input + PepperingValue);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        public override string ComputeHash(string password, byte[]? salt)
        {
            throw new NotImplementedException();
        }
    }
}
