using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.CRM.Business.Helper
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class CryptoHelper
    {

        public static string ComputeHash(string input, string key)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                byte[] hashValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashValue).Replace("-", "").ToLower();
            }
        }
        public static string EncryptData(string text, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[16]; // IV should be unique and random

                using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                {
                    byte[] plaintextBytes = Encoding.UTF8.GetBytes(text);

                    using (var msEncrypt = new System.IO.MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            csEncrypt.Write(plaintextBytes, 0, plaintextBytes.Length);
                            csEncrypt.FlushFinalBlock();
                            byte[] encryptedBytes = msEncrypt.ToArray();
                            return Convert.ToBase64String(encryptedBytes);
                        }
                    }
                }
            }
        }

    }

}
