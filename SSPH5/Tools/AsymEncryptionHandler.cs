using System.Text;

namespace SSPH5.Tools
{
    public class AsymEncryptionHandler
    {
        private string _privateKey;
        private string _publicKey;

        public AsymEncryptionHandler()
        {
            using(System.Security.Cryptography.RSACryptoServiceProvider rsa = new())
            {
                _privateKey = rsa.ToXmlString(true);
                _publicKey = rsa.ToXmlString(false);
            }
        }
        public string EncryptAsym(string msg)=>
            AsymEncrypter.Encrypt(msg, _publicKey);

        public string DecryptAsym(string msg)
        {
            using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new())
            {
                rsa.FromXmlString(_privateKey);
                byte[] bMsg = Encoding.Unicode.GetBytes(msg);
                byte[] decryptedMsg = rsa.Decrypt(bMsg, true);
                return Convert.ToBase64String(decryptedMsg);
            }
        }

    }
}
