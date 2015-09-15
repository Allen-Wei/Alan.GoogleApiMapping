using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Alan.GoogleApiMapping.Configurations
{
    public static class ConfigUtils
    {
        private static ConfigModel _config;

        public static ConfigModel Current
        {
            get { return _config; }
        }

        static ConfigUtils()
        {
            _config = GetModel();
        }

        public static ConfigModel Refresh()
        {
            _config = GetModel();
            return _config;
        }



        private static ConfigModel GetModel()
        {
            var jsonPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/mapping.json");
            if (!File.Exists(jsonPath))
            {
                throw new FileNotFoundException("找不到配置文件");
            }

            var json = File.ReadAllText(jsonPath);
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Deserialize<ConfigModel>(json);
        }
    }
}