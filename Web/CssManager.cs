using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Xsation.Mvc.Helpers.HtmlElements;
using Xsation.Mvc.Helpers.Urls;

namespace Xsation.Library.Web
{
    public class CssManager
    {
        private Dictionary<string, string> _css = new Dictionary<string, string>();
        private IResolveUrls _resolver;

        public CssManager(IResolveUrls resolver)
        {
            this._resolver = resolver;
        }

        public CssManager Add(string path)
        {
            if (this._css == null)
                throw new InvalidOperationException("TOO LATE!, Cannot add css, css's have already been retrived");

            path = this._resolver.Resolve(path);

            if (this._css.ContainsKey(path))
                return this;

            this._css.Add(path, path);

            return this;
        }

        public string[] GetAll()
        {
            var result = this._css.Values.ToArray();
            this._css = null;
            return result;
        }

        public string RenderTags()
        {
            return this.GetAll().Select(x => new link() { rel = "stylesheet", href = x, media = "all" }).RenderItems();
        }
    }
}
