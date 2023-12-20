using System;
using System.Security.Cryptography;
using System.Text;

namespace WellnessNavigator1.Classes
{
    public class SHA256Algorithm : Algorithms
    {
        public override string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        public override string ComputeHash(string password, byte[]? salt)
        {
            throw new NotImplementedException();
        }
    }
}
