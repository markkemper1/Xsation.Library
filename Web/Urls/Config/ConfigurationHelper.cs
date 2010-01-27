using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using Xsation.Mvc.Helpers.MapUrl.Config;

namespace Xsation.Mvc.Helpers.Config
{
    public class IncludeConfig : IMapUrlConfiguration
    {
        private readonly IncludeConfiguration _config;
        private readonly Dictionary<string, string> _mappings = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);

        public IncludeConfig(IncludeConfiguration config)
        {
            if (config == null)
                return;

            this._config = config;
            this.IsActive = !this._config.Debug;

            foreach (IncludeElementCollection set in this._config.UrlMappings)
                foreach (IncludeElement se in set)
                    this._mappings.Add(se.IncludePath, set.Url);
        }

        public bool IsActive
        {
            get;
            set;
        }

        public bool IsMapped(string url)
        {
            return this._mappings.ContainsKey(url);
        }

        public string Map(string url)
        {
            if (!this.IsActive || !this.IsMapped(url))
                return url;

            return this._mappings[url];
        }

       
    }
}
