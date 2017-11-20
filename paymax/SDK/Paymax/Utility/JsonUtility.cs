using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Paymax.Utility
{
    public class JsonUtility
    {
        public static string ToJsonString(Dictionary<string, object> dicData)
        {
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(dicData);
        }

        public static T Deserialize<T>(string input)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(input);
        }
    }
}
