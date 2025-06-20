using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace MainModels.Util
{
    public class AESEncryption
    {
        private readonly string _key;

        public AESEncryption()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) // Set the base path
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            _key = WebUtility.HtmlDecode(config.GetValue<string>("SystemSettings:EncryptionKey"));
            if (string.IsNullOrEmpty(_key))
            {
                throw new ArgumentException("Encryption key is not configured.");
            }
        }
        public string Encrypt(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
            {
                return string.Empty;
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = GenerateKey(_key);
                aes.GenerateIV(); // Generate a unique IV for each encryption
                byte[] iv = aes.IV;

                using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(iv, 0, iv.Length); // Prepend IV to the ciphertext
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public string EncryptWithHash(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
            {
                return string.Empty;
            }

            // Step 1: Compute hash of the plaintext
            string hash = ComputeSHA256Hash(plainText);

            // Step 2: Encrypt the hash
            using (Aes aes = Aes.Create())
            {
                aes.Key = GenerateKey(_key);
                aes.GenerateIV(); // Generate a unique IV for each encryption
                byte[] iv = aes.IV;

                using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(iv, 0, iv.Length); // Prepend IV to the ciphertext
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(hash); // Encrypt the hash
                    }

                    byte[] encryptedData = ms.ToArray();
                    return Convert.ToBase64String(encryptedData);
                }
            }
        }


        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
            {
                return string.Empty;
            }

            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = GenerateKey(_key);

                using (MemoryStream ms = new MemoryStream(cipherBytes))
                {
                    byte[] iv = new byte[16];
                    ms.Read(iv, 0, iv.Length); // Extract IV from the ciphertext
                    aes.IV = iv;

                    using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        public string DecryptWithHash(string cipherText)
        {
            if (string.IsNullOrWhiteSpace(cipherText))
            {
                return string.Empty;
            }

            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = GenerateKey(_key);

                using (MemoryStream ms = new MemoryStream(cipherBytes))
                {
                    byte[] iv = new byte[16];
                    ms.Read(iv, 0, iv.Length); // Extract IV from the ciphertext
                    aes.IV = iv;

                    using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        string decryptedText = sr.ReadToEnd();

                        // For password verification, hash the decrypted password
                        string hashedDecryptedText = ComputeSHA256Hash(decryptedText);

                        return hashedDecryptedText;
                    }
                }
            }
        }



        private static byte[] GenerateKey(string key)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
            }
        }

        private string ComputeSHA256Hash(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}
