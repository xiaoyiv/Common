using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paymax
{
    public class RefundModel : PaymaxModel
    {
        /// <summary>
        /// 退款订单id，系统内唯一，以“re_”开头，后跟24位随机数
        /// </summary>
        public string id { get;set; }
        /// <summary>
        /// 商户订单号，在商户系统内唯一，8-20位数字或字母，不允许特殊字符
        /// </summary>
        public string order_no { get;set; }
        /// <summary>
        /// 退款订单对应的支付订单id
        /// </summary>
        public string charge { get;set; }
        /// <summary>
        /// 退款订单总金额，大于0的数字，单位是该币种的货币单位
        /// </summary>
        public decimal amount { get;set; }
        /// <summary>
        /// 特定渠道需要的的额外附加参数
        /// </summary>
        public Dictionary<string, Object> extra { get;set; }
        /// <summary>
        /// 退款备注，限制300个字符内
        /// </summary>
        public string description { get;set; }
        /// <summary>
        /// 支付渠道退款订单号
        /// </summary>
        public string transaction_no { get;set; }
        /// <summary>
        /// 用户自定义元数据
        /// </summary>
        public Dictionary<string, Object> metadata { get;set; }
        /// <summary>
        /// 订单创建时间，13位时间戳
        /// </summary>
        public long time_created { get;set; }
        /// <summary>
        /// 订单退款完成时间，13位时间戳
        /// </summary>
        public long time_succeed { get;set; }
        /// <summary>
        /// 订单的错误码
        /// </summary>
        public string failure_code { get;set; }
        /// <summary>
        /// 订单的错误消息的描述
        /// </summary>
        public string failure_msg { get;set; }
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
            builder.AppendLine("description=" + description);
            builder.Append("metadata ={ ");
            if (metadata != null)
            {
                foreach (KeyValuePair<string, object> data in metadata)
                {
                    builder.Append(data.Key + "=" + data.Value + ",");
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
                    builder.Append(item.Key + "=" + item.Value + ",");
                }
            }
            else
            {
                builder.Append("<null>");
            }
            builder.AppendLine("} ");

            builder.AppendLine("transaction_no=" + transaction_no);
            builder.AppendLine("time_created=" + time_created);
            builder.AppendLine("time_succeed=" + time_succeed);
            builder.AppendLine("failure_code=" + failure_code);
            builder.AppendLine("failure_msg=" + failure_msg);
            builder.AppendLine("status=" + status);
            builder.AppendLine("reqSuccessFlag=" + reqSuccessFlag);
            return builder.ToString();
        }

    }
}
