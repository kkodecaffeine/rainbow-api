using System;
using System.Security.Cryptography;
using System.Text;

namespace RainbowApp.Core.Helpers
{
    public static class StringUtil
    {
       
        /// <summary>
        /// 값을 SHA512 알고리즘으로 암호화 한다.
        /// </summary>
        /// <param name="stringToEncrypt"></param>
        /// <returns></returns>
        public static string EncryptToSHA256(this object stringToEncrypt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(stringToEncrypt.FixNull());
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}