using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paymax;
using Paymax.Config;
using Paymax.Utility;
using System.Web.Script.Serialization;

namespace Paymax.Business
{
    /// <summary>
    /// 退款业务类
    /// </summary>
    public class RefundBusiness : BaseBusiness
    {
        public RefundBusiness(string PRIVATE_KEY, string SECRET_KEY, string PAYMAX_PUBLIC_KEY)
        {
            this.PRIVATE_KEY = PRIVATE_KEY;
            this.SECRET_KEY = SECRET_KEY;
            this.PAYMAX_PUBLIC_KEY = PAYMAX_PUBLIC_KEY;
        }
        /// <summary>
        /// 创建退款请求
        /// </summary>
        /// <param name="argChargeId"></param>
        /// <param name="argParams"></param>
        /// <returns></returns>
        public RefundModel Create(string argChargeId, Dictionary<string, object> argParams)
        {
            RefundModel model = null;


            string url = PaymaxConfig.API_BASE_URL + PaymaxConfig.CREATE_CHARGE + "/" + argChargeId + "/refunds";
            string jsonData = JsonUtility.ToJsonString(argParams);

            Dictionary<string, string> result = Request(url, jsonData);

            model = convertToModel<RefundModel>(result);

            return model;
        }

        /// <summary>
        /// 退款结果查询
        /// </summary>
        /// <param name="argChargeId">支付订单编号</param>
        /// <param name="argRefundId">退款订单编号</param>
        /// <returns></returns>
        public RefundModel Retrieve(string argChargeId, string argRefundId)
        {
            RefundModel model = null;


            string url = PaymaxConfig.API_BASE_URL + PaymaxConfig.CREATE_CHARGE + "/" + argChargeId + "/refunds/" + argRefundId;

            Dictionary<string, string> result = Request(url, null);

            model = convertToModel<RefundModel>(result);

            return model;
        }
    }
}
