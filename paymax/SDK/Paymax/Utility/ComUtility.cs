using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Paymax.Utility
{
    public class ComUtility
    {
        public static long ToMillisenconds()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (DateTime.Now.Ticks - startTime.Ticks) / 10000;            //除10000调整为13位
            Debug.WriteLine(t);
            return t;
        }
    }
}
