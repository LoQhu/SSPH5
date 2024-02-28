using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SSPH5.Tools;

public class AsymEncrypter
{
    public static string Encrypt(string msg, string publicKey)
    {
        using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new())
        {
            rsa.FromXmlString(publicKey);
            byte[] bMsg = Encoding.Unicode.GetBytes(msg);
            byte[] encryptedMsg = rsa.Encrypt(bMsg, true);
            return Convert.ToBase64String(encryptedMsg);
        }
    }
}
