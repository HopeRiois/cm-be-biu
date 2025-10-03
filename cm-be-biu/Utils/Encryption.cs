using System.Security.Cryptography;
using System.Text;

namespace cm_be_biu.Utils
{
    public class Encryption(string keyString)
    {
        private readonly byte[] _key = Encoding.UTF8.GetBytes(keyString);

        public string DecryptAES256(string cipherData)
        {
            //byte[] key = Encoding.UTF8.GetBytes(keyString);
            byte[] iv = new byte[16];
            try
            {
                using var aes = Aes.Create();
                aes.Key = _key;
                aes.IV = iv;
                aes.Mode = CipherMode.CBC;
                using var memoryStream =
                   new MemoryStream(Convert.FromBase64String(cipherData));
                using var cryptoStream =
                       new CryptoStream(memoryStream,
                           aes.CreateDecryptor(_key, iv),
                           CryptoStreamMode.Read);
                return new StreamReader(cryptoStream).ReadToEnd();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return "";
            }
        }

        public string EncryptAES256(string message)
        {
            //byte[] Key = ASCIIEncoding.UTF8.GetBytes(KeyString);
            byte[] IV = new byte[16];

            string encrypted = "";
            var rj = Aes.Create();
            rj.Key = _key;
            rj.IV = IV;
            rj.Mode = CipherMode.CBC;

            try
            {
                MemoryStream ms = new();

                using (CryptoStream cs = new(ms, rj.CreateEncryptor(_key, IV), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new(cs))
                    {
                        sw.Write(message);
                        sw.Close();
                    }
                    cs.Close();
                }
                byte[] encoded = ms.ToArray();
                encrypted = Convert.ToBase64String(encoded);

                ms.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return encrypted;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return encrypted;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: {0}", e.Message);
            }
            finally
            {
                rj.Clear();
            }
            return encrypted;
        }

    }
}
