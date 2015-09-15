using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alan.GoogleApiMapping.Configurations
{
    /// <summary>
    /// Summary description for RefreshConfig
    /// </summary>
    public class RefreshConfig : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var config = Alan.GoogleApiMapping.Configurations.ConfigUtils.Refresh().ToJson();
            context.Response.Write(config);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}