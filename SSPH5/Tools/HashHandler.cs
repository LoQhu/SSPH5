using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace SSPH5.Tools
{
    public class HashHandler
    {
        private byte[]? _input = null;

        public HashHandler(string textInput) { 
            _input = Encoding.Unicode.GetBytes(textInput);
        }
        public HashHandler(byte[] byteInput) { 
            _input = byteInput;
        }
        public dynamic MD5Hash(string returnType="SimpleString")
        {
            MD5 md5 = MD5.Create();
            byte[] md5Hash = md5.ComputeHash(_input);
            if(returnType == "SimpleString") return Convert.ToBase64String(md5Hash);
            if(returnType == "ByteArray") return md5Hash;
            if(returnType == "UTFString") return Encoding.UTF32.GetString(md5Hash);
            if(returnType == "Hex") return Convert.ToHexString(md5Hash);
            if(returnType == "ByteString") return Convert.ToByte(md5Hash).ToString();

            return null;

        }

        public dynamic SHAHash(string returnType = "SimpleString")
        {
            SHA256 sha = SHA256.Create();
            byte[] hashedValue = sha.ComputeHash(_input);
            if (returnType == "SimpleString") return Convert.ToBase64String(hashedValue);
            if (returnType == "ByteArray") return hashedValue;
            if (returnType == "UTFString") return Encoding.UTF32.GetString(hashedValue);
            if (returnType == "Hex") return Convert.ToHexString(hashedValue);
            if (returnType == "ByteString") return Convert.ToByte(hashedValue).ToString();
            return null;
        }
        public dynamic HMACHash(string keyT,string returnType)
        {
            HMACSHA256 hmac = new HMACSHA256();
            hmac.Key = Encoding.Unicode.GetBytes("ContemplateTheGreatPlan");
            byte[] hashedValue = hmac.ComputeHash(_input);
            if (returnType == "SimpleString") return Convert.ToBase64String(hashedValue);
            if (returnType == "ByteArray") return hashedValue;
            if (returnType == "UTFString") return Encoding.UTF32.GetString(hashedValue);
            if (returnType == "Hex") return Convert.ToHexString(hashedValue);
            if (returnType == "ByteString") return Convert.ToByte(hashedValue).ToString();
            return null;
        }

        public dynamic PBKDF2Hash(string salt, string returnType)
        {
            byte[] saltByte = Encoding.Unicode.GetBytes(salt);
            var hashAlgo = new HashAlgorithmName("SHA256");

            byte[] hashedValue = Rfc2898DeriveBytes.Pbkdf2(_input, saltByte,10,hashAlgo,32);
            if (returnType == "SimpleString") return Convert.ToBase64String(hashedValue);
            if (returnType == "ByteArray") return hashedValue;
            if (returnType == "UTFString") return Encoding.UTF32.GetString(hashedValue);
            if (returnType == "Hex") return Convert.ToHexString(hashedValue);
            if (returnType == "ByteString") return Convert.ToByte(hashedValue).ToString();
            return null;
        }

        public static dynamic BKCYPTHash(string inputToHash, string returnType)
        {
            byte[] hashedValue = Encoding.Unicode.GetBytes(BCrypt.Net.BCrypt.HashPassword(inputToHash, 10, true));
            if (returnType == "SimpleString") return Convert.ToBase64String(hashedValue);
            if (returnType == "ByteArray") return hashedValue;
            if (returnType == "UTFString") return Encoding.UTF32.GetString(hashedValue);
            if (returnType == "Hex") return Convert.ToHexString(hashedValue);
            if (returnType == "ByteString") return Convert.ToByte(hashedValue).ToString();
            return null;
        }
        public static bool BCRYPTVerify(string inputToVerify,string hashedValue)
        {
           return BCrypt.Net.BCrypt.Verify(inputToVerify, hashedValue,true);
        }

    }
}
