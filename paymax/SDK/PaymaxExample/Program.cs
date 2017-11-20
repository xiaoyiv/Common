using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paymax;
using Paymax.Utility;
using System.Diagnostics;

namespace PaymaxExample
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymaxClient payClient = new PaymaxClient(
                "<RSAKeyValue><Modulus>oj2VE+6GewoOqyv6JcRldTrAMhQ7SbMg9evK7rwAt+7dZGb4xlULNzcevvkifUxt279Rx0Yr1/ERFKqNdoFYo93d6mMqigAmtS/3i6t0Q3fj3PmB4zE3UPAIE/Wa5vQjdpX8Ci/4gfTF0H1vjY2WvKt1cXF0dgqkSv/urGtl48c=</Modulus><Exponent>AQAB</Exponent><P>2W7nzKEDiXG/QPrsg3kWVI/hNDMXL634KRDGJNGLP+bocX8EgGsdEXolToMJMKg8NdTdrVUpyBjWeNJa3JEGOw==</P><Q>vwSEVnrwSnJ9AgUqxqtv2vsp7jlOPCLDryQE5pQU3c2jzk6YE9EOGrH9/zTvLPPGj1n6D97RYzJKgzKCDB/j5Q==</Q><DP>HAqVkmphjmRBChxSTFJdcuJrZNQB9YA2NPWY2D69+qvI5no/FmC6Cvr5vLphgQjxWu/s9uG41bl+T26xkSiS6Q==</DP><DQ>AEPmVyRmjwPnrogJTitQxXIR1dXYiPbXZLfdFeDgwooVjyTGy0hAB8N1gdQ1/M792JccZMc/bS7VsabxTUkCDQ==</DQ><InverseQ>EiTBH5oIcQUAj5FJuIGoU2FyM3ZdGZZ3wyELFqC6fPbdpRqAJ2Nq4Yb0JEpuOo/fVEIxuo2EnHrMmuB2T1WqsA==</InverseQ><D>KttZpgo8PARMG6tiSNe4dV8vpgryHmXTLyM6WBYRmoTetsb8sGeGru9Aj/H/ylmGK6Y+VAWVT1W+zVbAR62jXDo6B1+kesb2SDtQos2R4s5ZqBTI+JBMqNXCWmCD8lJyujRJz2p0NfiHn9gbBq3F7ZWG0NNstQiK5S5jdQ1yAQE=</D></RSAKeyValue>",
                "46deeed7d7ac48f3848a908a9093c4b8",
                "<RSAKeyValue><Modulus>r3qZJHOD0uB4fyIrAigTGRQV0lr3VPFlaLwSbCuXpLirxogqunSAFUOb8przKvd4ntf5DlcrP0RCPQosj0Awo3IacaKxobWTfm1NXJEc/GumLY5Kd7s8fD3WoGrpmrT3AtpEkl7iuyKdNVktDSpSjM5KMDXcj/BFmFEFBpnPjsE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
                );
            string CHARGE_CHANNEL = "lakala_web";
            string app_id = "app_DB1U6RUK4K6741UO";
            Dictionary<string, object> paramDic = CreateChargeParmeters(CHARGE_CHANNEL,app_id);

            try
            {
                //下单
                Console.WriteLine("开始下单：");
                CreateCharge(payClient, paramDic);

                Console.WriteLine("开始查询订单：");
                ////查询订单
                RetriveCharge(payClient);

                Console.WriteLine("开始创建退款订单：");
                //创建退款订单
                CreateRefundCharge(payClient);

                Console.WriteLine("开始查询退款订单");
                //查询退款订单
                RetriveRefundCharge(payClient);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error:" + ex.Message);
            }

            System.Console.ReadLine();
        }

        /// <summary>
        /// 创建退款订单
        /// </summary>
        /// <param name="payClient"></param>
        private static void CreateRefundCharge(PaymaxClient payClient)
        {
            Dictionary<string, object> dic = CreateRefundParmeters();
            String charge = "ch_e4cbdb4c9aa9cca77ae49b06";
            RefundModel refundModel = payClient.Refund(charge, dic);
            if (refundModel != null)
            {
                Debug.WriteLine("查询订单:" + refundModel.id);
                Console.WriteLine(refundModel.id);
            }
            else
            {
                Console.WriteLine("查询订单失败");
            }
        }

        /// <summary>
        /// 创建支付订单
        /// </summary>
        /// <param name="payClient"></param>
        /// <param name="paramDic"></param>
        private static void CreateCharge(PaymaxClient payClient, Dictionary<string, object> paramDic)
        {
            ChargeModel result = payClient.Charge(paramDic);
            if (result != null)
            {
                Console.WriteLine("下单成功");
                Debug.WriteLine(result);
                //输出订单信息
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("下单失败");
            }
        }

       /// <summary>
       /// 查询支付订单
       /// </summary>
       /// <param name="payClient"></param>
        private static void RetriveCharge(PaymaxClient payClient)
        {
            String chargeId = "ch_db8c1014e985bdf6f9fa562e";
            ChargeModel model = payClient.RetrieveCharge(chargeId);
            if (model != null)
            {
                Debug.WriteLine("查询订单:" + model.id);
                Console.WriteLine(model);
            }
            else
            {
                Console.WriteLine("查询订单失败");
            }
        }

        /// <summary>
        /// 查询退款订单
        /// </summary>
        /// <param name="payClient"></param>
        private static void RetriveRefundCharge(PaymaxClient payClient)
        {
            String ch_chargeId = "ch_e4cbdb4c9aa9cca77ae49b06";
            String re_chargeId = "re_50c188e484d82273e00a4bcf";
            RefundModel rm = payClient.RetrieveRefund(ch_chargeId, re_chargeId);
            if (rm != null)
            {
                Debug.WriteLine("查询退款订单:" + rm.id);
                Console.WriteLine(rm.id);
            }
            else
            {
                Console.WriteLine("查询退款订单失败");
            }
        }

        /// <summary>
        /// 创建支付订单的Dictionary参数
        /// </summary>
        /// <param name="CHARGE_CHANNEL">支付渠道编码</param>
        /// <param name="app_id">应用的ID</param>
        /// <returns></returns>
        private static Dictionary<string, object> CreateChargeParmeters(string CHARGE_CHANNEL,string app_id)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("amount", 0.1);
            paramDic.Add("subject", "my subject");
            paramDic.Add("body", "my body");
            paramDic.Add("order_no", Guid.NewGuid());
            paramDic.Add("channel", CHARGE_CHANNEL);
            paramDic.Add("client_ip", "127.0.0.1");
            paramDic.Add("app", app_id);
            paramDic.Add("currency", "CNY");
            paramDic.Add("description", "my description");
            Dictionary<string, object> extra = new Dictionary<string, object>();
            extra.Add("user_id", "13601602858");
            extra.Add("return_url", "http://www.baidu.com");
            paramDic.Add("extra", extra);

            //Dictionary<string, object> metadata = new Dictionary<string, object>();
            //metadata.Add("metadata_key1", "metadata_value1");
            //metadata.Add("metadata_key2", "metadata_value2");

            //paramDic.Add("metadata", metadata);
            return paramDic;
        }

        /// <summary>
        /// 创建退款订单的参数
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, object> CreateRefundParmeters()
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("amount", 0.1);
            paramDic.Add("description", "协商一致退款。");

            Dictionary<string, object> extra = new Dictionary<string, object>();
            extra.Add("user_id", "1511000000");
            paramDic.Add("extra", extra);

            Dictionary<string, object> metadata = new Dictionary<string, object>();
            metadata.Add("metadata_key1", "metadata_value1");
            metadata.Add("metadata_key2", "metadata_value2");

            paramDic.Add("metadata", metadata);
            return paramDic;
        }
    }
}
