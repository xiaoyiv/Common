using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paymax
{
    public class ChargeModel : PaymaxModel
    {
        /// <summary>
        /// 支付订单id，系统内唯一，以“ch_”开头，后跟24位随机数
        /// </summary>
        public string id { get;set; }

        /// <summary>
        /// 商户订单号，在商户系统内唯一，8-20位数字或字母，不允许特殊字符
        /// </summary>
        public string order_no { get;set; }
        /// <summary>
        /// 订单总金额，大于0的数字，单位是该币种的货币单位
        /// </summary>
        public decimal amount { get;set; }
        /// <summary>
        /// 购买商品的标题，最长32位
        /// </summary>
        public string subject { get;set; }
        /// <summary>
        /// 购买商品的描述信息，最长128个字符
        /// </summary>
        public string body { get;set; }
        /// <summary>
        /// 支付渠道编码，唯一标识一个支付渠道
        /// </summary>
        public string channel { get;set; }
        /// <summary>
        /// 发起支付的客户端IP
        /// </summary>
        public string client_ip { get;set; }
        /// <summary>
        /// 订单备注，限制300个字符内
        /// </summary>
        public string description { get;set; }
        /// <summary>
        /// 用户自定义元数据
        /// </summary>
        public Dictionary<string, Object> metadata { get;set; }
        /// <summary>
        /// 特定渠道需要的的额外附加参数
        /// </summary>
        public Dictionary<string, Object> extra { get;set; }
        /// <summary>
        /// 支付渠道订单号
        /// </summary>
        public string transaction_no { get;set; }
        /// <summary>
        /// 应用的appKey
        /// </summary>
        public string app { get;set; }
        /// <summary>
        /// 已结算金额
        /// </summary>
        public decimal amount_settle { get;set; }
        /// <summary>
        /// 三位ISO货币代码，只支持人民币cny，默认cny
        /// </summary>
        public string currency { get;set; }
        /// <summary>
        /// 已退款金额
        /// </summary>
        public decimal amount_refunded { get;set; }
        /// <summary>
        /// 是否已经开始退款
        /// </summary>
        public bool refunded { get;set; }
        /// <summary>
        /// 退款记录
        /// </summary>
        public List<RefundModel> refunds { get;set; }
        /// <summary>
        /// 订单创建时间，13位时间戳
        /// </summary>
        public long time_created { get;set; }
        /// <summary>
        /// 订单支付完成时间，13位时间戳
        /// </summary>
        public long time_paid { get;set; }
        /// <summary>
        /// 订单失效时间，13位时间戳
        /// </summary>
        public long time_expire { get;set; }
        /// <summary>
        /// 订单结算时间，13位时间戳
        /// </summary>
        public long time_settle { get;set; }
        /// <summary>
        /// 支付凭据，用于调起支付APP或者跳转支付网关
        /// </summary>
        public Dictionary<string, Object> credential { get;set; }
        /// <summary>
        /// 订单的错误码
        /// </summary>
        public string failure_code { get;set; }
        /// <summary>
        /// 订单的错误消息的描述
        /// </summary>
        public string failure_msg { get;set; }
        /// <summary>
        /// 是否是生产模式
        /// </summary>
        public Boolean livemode { get;set; }
        /// <summary>
        /// 订单状态，只有三种（PROCESSING-处理中，SUCCEED-成功，FAILED-失败）
        /// </summary>
        public string status { get;set; }
        /// <summary>
        /// 本次请求是否成功 true:成功,false:失败
        /// </summary>
        public bool reqSuccessFlag { get;set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("id=" + id);
            builder.AppendLine("order_no=" + order_no);
            builder.AppendLine("amount=" + amount);
            builder.AppendLine("subject=" + subject);
            builder.AppendLine("body=" + body);
            builder.AppendLine("channel=" + channel);
            builder.AppendLine("client_ip=" + client_ip);
            builder.AppendLine("description=" + description);
            builder.Append("metadata ={ ");
            if (metadata!=null)
            {
                foreach (KeyValuePair<string,object> data in metadata)
                {
                    builder.Append( data.Key+"="+data.Value+",");
                }
            }
            else
            {
                builder.Append("<null>");
            }
            builder.AppendLine("} ");

            builder.Append("extra ={ ");
            if (metadata != null)
            {
                foreach (KeyValuePair<string, object> item in extra)
                {
                    builder.Append(item.Key +"="+ item.Value + ",");
                }
            }
            else
            {
                builder.Append("<null>");
            }
            builder.AppendLine("} ");
      
            builder.AppendLine("transaction_no=" + transaction_no);
            builder.AppendLine("app=" + app);
            builder.AppendLine("amount_settle=" + amount_settle);
            builder.AppendLine("currency=" + currency);
            builder.AppendLine("amount_refunded=" + amount_refunded);
            builder.AppendLine("refunded=" + refunded);

            List<RefundModel> list = refunds;
            builder.Append("refunds=[" );
            if (refunds!=null)
            {
                for (int i = 0; i < refunds.Count; i++)
                {
                    builder.Append("退款订单id=" + refunds[i].id+ ",退款订单对应的支付订单id=" + refunds[i].charge);
                }
            }
         
            builder.AppendLine("] ");
            builder.AppendLine("time_created=" + time_created);
            builder.AppendLine("time_paid=" + time_paid);
            builder.AppendLine("time_expire=" + time_expire);
            builder.AppendLine("time_settle=" + time_settle);

            builder.Append("credential ={ ");
            if (metadata != null)
            {
                foreach (KeyValuePair<string, object> item in credential)
                {
                    builder.Append(item.Key+"=");
                    Dictionary<string, object> value = item.Value as Dictionary<string, object>;
                    if (value != null)
                    {
                        foreach (var sub in value)
                        {
                            builder.Append(sub.Key + ":" + sub.Value);
                        }
                    }
                    else
                    {
                        builder.Append(item.Value);
                    }
                }
            }
            else
            {
                builder.Append("<null>");
            }
            builder.AppendLine("} ");

            builder.AppendLine("failure_code=" + failure_code);
            builder.AppendLine("failure_msg=" + failure_msg);
            builder.AppendLine("livemode=" + livemode);
            builder.AppendLine("status=" + status);
            builder.AppendLine("reqSuccessFlag=" + reqSuccessFlag);
            return builder.ToString();
        }
    }
}
