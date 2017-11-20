using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Paymax.Utility
{
    public class RSAUtility
    {
        public static string ALGORITHM = "RSA";

        public static string SIGN_ALGORITHMS = "SHA1WithRSA";// 摘要加密算饭

        private static string log = "RSAUtil";

        public static string CHAR_SET = "UTF-8";

        private static bool getHashData(string strSource, ref byte[] HashData)
        {
            try
            {
                byte[] Buffer;
                System.Security.Cryptography.HashAlgorithm SHA1 = System.Security.Cryptography.HashAlgorithm.Create(SIGN_ALGORITHMS);
                System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
                Buffer = System.Text.Encoding.GetEncoding(CHAR_SET).GetBytes(strSource);
                HashData = sha1.ComputeHash(Buffer);
                return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static string GenerateKey(bool isPrivateKey)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            return RSA.ToXmlString(isPrivateKey);
        }

        public static string Sign(string content, string privateKey)
        {
            try
            {
                byte[] rgbHashData = null;

                getHashData(content, ref rgbHashData);

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(privateKey);

                RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(rsa);
               formatter.SetHashAlgorithm("SHA1");//"SHA1" SIGN_ALGORITHMS
                byte[] inArray = formatter.CreateSignature(rgbHashData);

                return Convert.ToBase64String(inArray);//encode
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            return null;
        }

        public static bool Verify(string content, string sign,
            string public_key)
        {
            try
            {
                byte[] rgbHashData = null;
                getHashData(content, ref rgbHashData);
                //rgbHashData = Encoding.UTF8.GetBytes(content);

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(public_key);
                RSAPKCS1SignatureDeformatter deFormatter = new RSAPKCS1SignatureDeformatter(rsa);
               // deFormatter.SetHashAlgorithm(SIGN_ALGORITHMS);
                deFormatter.SetHashAlgorithm("SHA1");
                bool bVerify = deFormatter.VerifySignature(rgbHashData, Convert.FromBase64String(sign));

                return bVerify;
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            return false;
        }
    }

}
