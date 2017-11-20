using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paymax.Config;
using Paymax.Excep;
using System.Net;
using Paymax.Utility;
using System.IO;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace Paymax.Business
{
    public class BaseBusiness
    {
        internal BaseBusiness() { }
        public BaseBusiness(string PRIVATE_KEY, string SECRET_KEY, string PAYMAX_PUBLIC_KEY)
        {
            this.PRIVATE_KEY = PRIVATE_KEY;
            this.SECRET_KEY = SECRET_KEY;
            this.PAYMAX_PUBLIC_KEY = PAYMAX_PUBLIC_KEY;
        }
        /// <summary>
        /// 商户自己的私钥【用com.Paymax.sign.RSAKeyGenerateUtil生成RSA秘钥对，公钥通过Paymax网站上传到Paymax，私钥设置到下面的变量中】
        /// </summary>
        public string PRIVATE_KEY = "";
        /// <summary
        /// Paymax提供给商户的SecretKey，登录网站后查看
        /// </summary>
        public string SECRET_KEY = "";

        /// <summary>
        /// Paymax提供给商户的公钥，登录网站后查看
        /// </summary>
        public string PAYMAX_PUBLIC_KEY = "";
        private static string HEADER_KEY_NONCE = "nonce";
        private static string HEADER_KEY_TIMESTAMP = "timestamp";
        private static string HEADER_KEY_AUTHORIZATION = "Authorization";
        protected static string RESPONSE_CODE = "code";
        protected static string RESPONSE_DATA = "data";
        private static int VALID_RESPONSE_TTL = 2 * 60 * 1000;//合法响应时间:2分钟内

        protected Dictionary<string, string> Request(string url, string jsonReqData)
        {
            if (string.IsNullOrEmpty(SECRET_KEY))
            {
                throw new AuthorizationException("Secret key can not be blank.Please set your Secret key in Paymax.Config.SignConfig");
            }

            if (string.IsNullOrEmpty(PRIVATE_KEY))
            {
                throw new AuthorizationException("RSA Private key can not be blank.Please set your RSA Private key  in Paymax.Config.SignConfig");
            }

            if (string.IsNullOrEmpty(PAYMAX_PUBLIC_KEY))
            {
                throw new InvalidRequestException("Paymax Public key can not be blank.Please set your Paymax Public key in Paymax.Config.SignConfig");
            }

            Dictionary<string, string> result = null;
            if (string.IsNullOrEmpty(jsonReqData))
            {
                result = buildGetRequest(url);
            }
            else
            {
                result = buildPostRequest(url, jsonReqData);
            }

            return result;
        }

        private Dictionary<string, string> buildPostRequest(string url, string jsonReqData)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            HttpWebRequest request = RequestUtility.CreatePostHttpRequest(url);

            byte[] data = ToBytes(jsonReqData);
            using (System.IO.Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            request.KeepAlive = true;
            setCustomHeaders(request);

            Console.WriteLine("请求的信息：");
            Console.WriteLine(request.Address);
            Console.WriteLine(request.Method);
            Console.WriteLine(jsonReqData);

            string strSignData = signData(request, data);
            Console.WriteLine("请求的签名结果："+strSignData);

            //Debug 输出信息
            Debug.WriteLine("=================请求的签名结果 start===============================");
            Debug.WriteLine(strSignData);
            Debug.WriteLine("=================请求的签名结果  end===============================");

            request.Headers.Add(PaymaxConfig.SIGN, strSignData);

            WebResponse response = null;
            Stream stream2 = null;
            try
            { 
                response = request.GetResponse();
            }
            catch (WebException we)
            {
                stream2 = we.Response.GetResponseStream();
                StreamReader sr = new StreamReader(stream2);
                string body = sr.ReadToEnd();
                Console.WriteLine("响应的body-错误信息：" + body);
                throw we;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw ex;
            }

            if (response == null)
            {
                throw new Exception("返回相应为null.");
            }

            HttpWebResponse httpResponse = response as HttpWebResponse;

            result = verifyData(httpResponse);

            return result;
        }

        private Dictionary<string, string> buildGetRequest(string url)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            HttpWebRequest request = RequestUtility.CreateGetHttpRequest(url);

            request.KeepAlive = true;
            setCustomHeaders(request);

            string strSignData = signData(request);

            //Debug.WriteLine("=================================================");
            //Debug.WriteLine(strSignData);
            //Debug.WriteLine("=================================================");

            request.Headers.Add(PaymaxConfig.SIGN, strSignData);

            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw ex;
            }

            if (response == null)
            {
                throw new Exception("返回相应为null.");
            }

            HttpWebResponse httpResponse = response as HttpWebResponse;

            result = verifyData(httpResponse);

            return result;
        }

        private string dealWithResult(Dictionary<string, string> argParams)
        {
            return "";
        }

        private void setCustomHeaders(HttpWebRequest request)
        {
            request.Headers.Add(HEADER_KEY_AUTHORIZATION, SECRET_KEY);

            long timestamp = ComUtility.ToMillisenconds();
            request.Headers.Add(HEADER_KEY_TIMESTAMP, timestamp.ToString());
            request.Headers.Add(HEADER_KEY_NONCE, randomUUID(20));
        }

        private static string randomUUID(int Length)
        {
            char[] constant =
              {
                '0','1','2','3','4','5','6','7','8','9',
                'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
              };
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }

        private string signData(HttpWebRequest request, byte[] request_data = null)
        {
            System.IO.MemoryStream output = new System.IO.MemoryStream();
            //签名前以 换行符（"\n"） 拼接各个字段：
            // method+"\n"+uri+"\n"+query_string+"\n"+nonce+"\n"+timestamp+"\n"+Authorization+"\n"+request_data

            byte[] data = ToBytes(request.Method.ToLower());
            output.Write(data, 0, data.Length);
            output.WriteByte((byte)'\n');//method

            string uri = request.RequestUri.AbsoluteUri;
            if (string.IsNullOrEmpty(uri))
            {
                uri = "";
            }
            int index = uri.IndexOf("/v1/");
            if (index != -1)
            {
                uri = uri.Substring(index);
            }
            data = ToBytes(uri);
            output.Write(data, 0, data.Length);
            output.WriteByte((byte)'\n');//uri path

            data = ToBytes(request.RequestUri.Query);
            output.Write(data, 0, data.Length);
            output.WriteByte((byte)'\n');//query_string

            data = ToBytes(request.Headers[HEADER_KEY_NONCE]);
            output.Write(data, 0, data.Length);
            output.WriteByte((byte)'\n');//nonce

            data = ToBytes(request.Headers[HEADER_KEY_TIMESTAMP]);
            output.Write(data, 0, data.Length);
            output.WriteByte((byte)'\n');//timestamp

            data = ToBytes(request.Headers[HEADER_KEY_AUTHORIZATION]);
            output.Write(data, 0, data.Length);
            output.WriteByte((byte)'\n');//Authorization

            //  request_data = new byte[1024];
            if (request_data != null)
            {
                output.Write(request_data, 0, request_data.Length);
            }

            string toSignString = System.Text.Encoding.UTF8.GetString(output.ToArray());
            output.Close();

            Debug.WriteLine("要签名的字符串：" + toSignString);
            return RSAUtility.Sign(toSignString, PRIVATE_KEY);
        }

        private Dictionary<string, string> verifyData(HttpWebResponse response)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new System.Exception("error code:" + response.StatusCode + ". message:" + response.StatusDescription);
            }

            string nonce = response.Headers[HEADER_KEY_NONCE] != null ? response.Headers[HEADER_KEY_NONCE] : "";
            string timestamp = response.Headers[HEADER_KEY_TIMESTAMP] != null ? response.Headers[HEADER_KEY_TIMESTAMP] : "";
            string secretKey = response.Headers[HEADER_KEY_AUTHORIZATION] != null ? response.Headers[HEADER_KEY_AUTHORIZATION] : "";

            System.IO.MemoryStream output = new System.IO.MemoryStream();
            byte[] data = this.ToBytes(nonce);
            output.Write(data, 0, data.Length);
            output.WriteByte((byte)'\n');//header

            data = this.ToBytes(timestamp);
            output.Write(data, 0, data.Length);
            output.WriteByte((byte)'\n');//header

            data = this.ToBytes(secretKey);
            output.Write(data, 0, data.Length);
            output.WriteByte((byte)'\n');//header

            System.IO.Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string body = sr.ReadToEnd();

            Console.WriteLine("响应的body："+body);
            Debug.WriteLine("响应的body：" + body);

            data = this.ToBytes(body);
            output.Write(data, 0, data.Length);

            string verifyData = System.Text.Encoding.UTF8.GetString(output.ToArray());

            string sign = response.Headers[PaymaxConfig.SIGN] != null ? response.Headers[PaymaxConfig.SIGN] : "";

            bool flag = RSAUtility.Verify(verifyData, sign, PAYMAX_PUBLIC_KEY);
            if (!flag)
            {
                throw new InvalidResponseException("Invalid Response.[Response Data And Sign Verify Failure.]");
            }

            if (!SECRET_KEY.Equals(secretKey))
            {
                throw new InvalidResponseException("Invalid Response.[Secret Key Is Invalid.]");
            }

            long currMillisenconds = ComUtility.ToMillisenconds();

            if (long.Parse(timestamp) + VALID_RESPONSE_TTL < currMillisenconds)
            {
                throw new InvalidResponseException("Invalid Response.[Response Time Is Invalid.]");
            }

            result = new Dictionary<string, string>();

            result.Add(RESPONSE_CODE, response.StatusCode.ToString());
            result.Add(RESPONSE_DATA, body);

            return result;
        }

        private byte[] ToBytes(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        protected T convertToModel<T>(Dictionary<string, string> result)
        {
            if (result == null)
            {
                return default(T);
            }

            string resultData = result[RESPONSE_DATA];

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            T model = JsonUtility.Deserialize<T>(resultData);

            return model;
        }
    }
}
