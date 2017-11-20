using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paymax.Config
{
    public class PaymaxConfig
    {
        /// <summary>
        /// Paymax服务器地址
        /// </summary>
        public static readonly string API_BASE_URL = "https://www.paymax.cc/merchant-api/";

        /// <summary>
        /// 请求method
        /// </summary>
        public static readonly string CREATE_CHARGE = "v1/charges";

        /// <summary>
        /// 编码集
        /// </summary>
        public static readonly string CHARSET = "UTF-8";

        public static readonly string APPLICATION_JSON = "application/json";
        /// <summary>
        /// 签名后数据的key
         /// </summary>
        public static readonly string SIGN = "sign";

        /// <summary>
        /// 返回数据的key
        /// </summary>
        public static readonly string RESDATA = "res_data";

        /// <summary>
        /// SDK版本
        /// </summary>
        public static readonly string SDK_VERSION = "1.0.0";

        /// <summary>
        /// 支付渠道编码，唯一标识一个支付渠道 拉卡拉 PC 端支付
        /// </summary>
        public static readonly string CHARGE_CHANNEL = "lakala_web";
    }
}
