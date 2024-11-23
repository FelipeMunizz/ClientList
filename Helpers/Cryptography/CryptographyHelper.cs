using Helpers.Utility;
using System.Security.Cryptography;
using System.Text;

namespace Helpers.Cryptography;

public class CryptographyHelper
{
    private readonly string _key;
    private readonly string _iv;

    public CryptographyHelper()
    {
        _key = Util.KeyCryptography;
        _iv = Util.IvCryptography;
    }
    /// <summary>
    /// Método responsável por criptografar dados
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    public string Encrypt(string plainText)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(_key);
            aes.IV = Encoding.UTF8.GetBytes(_iv);

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var writer = new StreamWriter(cs))
                        {
                            writer.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }

    /// <summary>
    /// Método responsável por descriptografar dados
    /// </summary>
    /// <param name="cipherText"></param>
    /// <returns></returns>
    public string Decrypt(string cipherText)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(_key);
            aes.IV = Encoding.UTF8.GetBytes(_iv);

            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            {
                using (var ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(cs))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
