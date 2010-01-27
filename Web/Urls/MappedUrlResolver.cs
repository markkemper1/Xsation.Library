using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xsation.Mvc.Helpers.MapUrl.Config;

namespace Xsation.Mvc.Helpers.Urls
{
    public class MappedUrlResolver : IResolveUrls
    {
        private IResolveUrls _baseResolver;
        private IMapUrlConfiguration _config;

        public MappedUrlResolver(IResolveUrls baseResolver, IMapUrlConfiguration config)
        {
            this._baseResolver = baseResolver;
            this._config = config;
        }

        public string Resolve(string url)
        {
            if (this._config.IsMapped(url))
                url = this._config.Map(url);

            return this._baseResolver.Resolve(url);
        }
    }
}