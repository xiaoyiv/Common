using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Paymax.Config;
using Paymax.Excep;
using System.IO;

namespace Paymax.Business
{
    public class RequestUtility

    {
        private static readonly string _DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; GTB6.6; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; MS-RTC LM 8)"; 

        public static HttpWebRequest CreateHttpRequest(string url, int? timeout = null, string userAgent = null, CookieCollection cookies = null)
        {
            HttpWebRequest request = null;

            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback =
                    new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }

            return request;
        }

        public static HttpWebRequest CreatePostHttpRequest(string url, int? timeout = null, string userAgent = null, CookieCollection cookies = null)
        {
            HttpWebRequest request = null;
            ServicePointManager.ServerCertificateValidationCallback =
                    new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(url) as HttpWebRequest;

            request.Method = "POST";

            request.ContentType = PaymaxConfig.APPLICATION_JSON + ";charset=" + PaymaxConfig.CHARSET;
            request.Credentials = CredentialCache.DefaultCredentials;//CredentialCache.DefaultCredentials;//new NetworkCredential(UserName, SecurelyStoredPassword, Domain);
            request.ProtocolVersion = HttpVersion.Version11;
            request.UserAgent = _DefaultUserAgent;

            return request;
        }

        public static HttpWebRequest CreateGetHttpRequest(string url, int? timeout = null, string userAgent = null, CookieCollection cookies = null)
        {
            HttpWebRequest request = null;

            request = WebRequest.Create(url) as HttpWebRequest;

            request.Method = "GET";
            request.ContentType = PaymaxConfig.APPLICATION_JSON + ";charset=" + PaymaxConfig.CHARSET;

            request.Credentials = new NetworkCredential("13601602858", "St123456");// CredentialCache.DefaultCredentials;//new NetworkCredential(UserName, SecurelyStoredPassword, Domain);
            request.ProtocolVersion = HttpVersion.Version11;
            request.UserAgent = _DefaultUserAgent;
            
            return request;
        }

        public static HttpWebResponse CreateGetHttpResponse(string url, int? timeout, string userAgent, CookieCollection cookies)
        {

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            
            request.Method = "GET";
            request.UserAgent = _DefaultUserAgent;
            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            return request.GetResponse() as HttpWebResponse;
        }

        protected static HttpWebResponse CreatePostHttpResponse(string url, Dictionary<string, object> paramsData, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            if (requestEncoding == null)
            {
                throw new ArgumentNullException("requestEncoding");
            }

            HttpWebRequest request = null;

            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback =
                    new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }

            request.Method = "POST";
            request.ContentType = "application/json;charset=" + PaymaxConfig.CHARSET;

            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            else
            {
                request.UserAgent = _DefaultUserAgent;
            }

            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }

            if (!(paramsData == null || paramsData.Count == 0))
            {
                StringBuilder sb = new StringBuilder();
                int i = 0;
                foreach (string key in paramsData.Keys)
                {
                    if (i > 0)
                    {
                        sb.AppendFormat("&{0}={1}", key, paramsData[key]);
                    }
                    else
                    {
                        sb.AppendFormat("{0}={1}", key, paramsData[key]);
                    }
                    i++;
                }

                byte[] data = requestEncoding.GetBytes(sb.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            return request.GetResponse() as HttpWebResponse;
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        } 
    }
}
