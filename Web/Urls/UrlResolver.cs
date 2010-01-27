using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.Urls
{
    public class UrlResolver : IResolveUrls
    {
        public string Resolve(string url)
        {
            if (String.IsNullOrEmpty(url))
                return String.Empty;

            if (System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath.Length == 1)
                return url.Replace("~", String.Empty);

            if (url.StartsWith("~/"))
                return url.Replace("~", System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);

            return url;
        }
    }
}
