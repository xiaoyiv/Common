using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paymax.Excep
{
    public class FailureCode
    {
        private static Dictionary<string, string> s_data = null;

        public FailureCode()
        {
            if (s_data == null)
            {
                s_data = new Dictionary<string, string>();

                s_data.Add("SECRET_KEY_IS_BLANK", "SecretKey为空");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
                s_data.Add("", "");
            }
        }
    }
}
