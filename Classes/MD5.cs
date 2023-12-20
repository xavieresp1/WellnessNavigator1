using System;
using System.Security.Cryptography;
using System.Text;

namespace WellnessNavigator1.Classes
{
    public class MD5Algorithm : Algorithms
    {
        public override string ComputeHash(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public override string ComputeHash(string password, byte[]? salt)
        {
            throw new NotImplementedException();
        }
    }
}
