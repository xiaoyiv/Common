using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Paymax
{
    public abstract class PaymaxModel
    {
        /// <summary>
        /// 一次性随机数
        /// </summary>
        public static string HEADER_KEY_NONCE = "nonce";
        /// <summary>
        /// 时间戳
        /// </summary>
        public static string HEADER_KEY_TIMESTAMP = "timestamp";
        /// <summary>
        /// 商户secret key,Paymax 提供给商户的唯一标识
        /// </summary>
        public static string HEADER_KEY_AUTHORIZATION = "Authorization";
        public static string REQUEST_SUCCESS_FLAG = "reqSuccessFlag";
        public static string RESPONSE_CODE = "code";
        public static string RESPONSE_DATA = "data";
        public static int VALID_RESPONSE_TTL = 2 * 60 * 1000;//合法响应时间:2分钟内

        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        { // 总是接受 
            return true;
        }
    }
}
