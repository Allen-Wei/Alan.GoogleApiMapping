using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Alan.GoogleApiMapping.Configurations
{
    public class ConfigModel
    {
        public List<ConfigMap> Maps { get; set; }

        public List<ConfigMap> Match(HttpRequest request)
        {
            var fileName = Path.GetFileName(request.RawUrl);
            var query = from map in this.Maps
                        where map.IsRegex ? Regex.IsMatch(request.RawUrl, map.Url, RegexOptions.IgnoreCase) : map.Url == fileName
                        select map;

            return query.ToList();
        }
        public string ToJson()
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Serialize(this);
        }
        public class ConfigMap
        {
            /// <summary>
            /// 是否是正则匹配
            /// </summary>
            public bool IsRegex { get; set; }
            /// <summary>
            /// URL
            /// </summary>
            public string Url { get; set; }
            /// <summary>
            /// 匹配到
            /// </summary>
            public string Target { get; set; }
        }
    }


}