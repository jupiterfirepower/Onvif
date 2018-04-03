using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Onvif.Contracts.Helper
{
    public class ConvertorHelper
    {
        public static string EncodeParameters(Dictionary<string, string> parameters)
        {
            return string.Join("&", parameters.Select(EncodeParameter).ToArray());
        }

        private static string EncodeParameter(KeyValuePair<string, string> parameter)
        {
            if (parameter.Value == null)
            {
                return string.Concat(WebUtility.UrlEncode(parameter.Key), "=");
            }
            return string.Concat(WebUtility.UrlEncode(parameter.Key), "=", WebUtility.UrlEncode(parameter.Value));
        }

        public static string DictionaryToJson(Dictionary<string, string> parameters)
        {
            string json = JsonConvert.SerializeObject(parameters, Formatting.None);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
