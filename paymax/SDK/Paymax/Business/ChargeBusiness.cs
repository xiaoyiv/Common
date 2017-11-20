using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paymax;
using Paymax.Config;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Paymax.Excep;
using Paymax.Utility;
using System.Web.Script.Serialization;

namespace Paymax.Business
{
    /// <summary>
    /// 支付业务类
    /// </summary>
    public class ChargeBusiness : BaseBusiness
    {
        public ChargeBusiness(string PRIVATE_KEY, string SECRET_KEY, string PAYMAX_PUBLIC_KEY)
        {
            this.PRIVATE_KEY = PRIVATE_KEY;
            this.SECRET_KEY = SECRET_KEY;
            this.PAYMAX_PUBLIC_KEY = PAYMAX_PUBLIC_KEY;
        }
        /// <summary>
        /// 创建充值订单
        /// </summary>
        /// <param name="argParams"></param>
        /// <returns></returns>
        public ChargeModel Charge(Dictionary<string, object> argParams)
        {
            ChargeModel model = null;


            string url = PaymaxConfig.API_BASE_URL + PaymaxConfig.CREATE_CHARGE;// + "?a=1&b=2&c=3";
            string jsonData = JsonUtility.ToJsonString(argParams);

            Dictionary<string, string> result = Request(url, jsonData);

            model = convertToModel<ChargeModel>(result);

            return model;
        }
        
        /// <summary>
        /// 查询充值订单
        /// </summary>
        /// <param name="argChargeId"></param>
        /// <returns></returns>
        public ChargeModel Retrieve(string argChargeId)
        {
            ChargeModel model = null;

            string url = PaymaxConfig.API_BASE_URL + PaymaxConfig.CREATE_CHARGE + "/" + argChargeId;

            Dictionary<string, string> result = Request(url, null);

            model = convertToModel<ChargeModel>(result);

            return model;
        }
    }
}
