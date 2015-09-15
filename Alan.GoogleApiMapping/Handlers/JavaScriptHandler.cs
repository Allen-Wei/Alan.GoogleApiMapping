using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Alan.GoogleApiMapping.Configurations;

namespace Alan.GoogleApiMapping.Handlers
{
    public class JavaScriptHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var req = context.Request;
            var rep = context.Response;
            rep.ContentType = "application/javascript; charset=utf-8";

            var map = ConfigUtils.Current.Match(req).FirstOrDefault();
            if (map == null)
            {
                rep.StatusCode = 404;
                rep.StatusDescription = "Can't find Map";
                return;
            }
            var target = HostingEnvironment.MapPath(map.Target ?? "");
            if (!File.Exists(target))
            {
                rep.StatusCode = 404;
                rep.StatusDescription = "Can't find file";
                rep.Headers.Add("X-Map-Target", map.Target);
                return;
            }
            rep.Write(File.ReadAllText(target));
        }

        public bool IsReusable { get; }
    }
}