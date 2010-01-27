using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class meta : element, INameAttribute
    {
        public meta() : base("meta") { this.SelfCloseTag(); }

        public string name
        {
            get { return this["name"]; }
            set { this["name"] = value; }
        }

        public string http_equiv
        {
            get { return this[" http-equiv"]; }
            set { this[" http-equiv"] = value; }
        }

        public string content
        {
            get { return this["content"]; }
            set { this["content"] = value; }
        }

        

        public static meta open() { return new meta(); }
    }

    
    public static class meta_Extensions
    {
        public static TSource content<TSource>(this TSource source, string value) where TSource : meta
        {
            source.content = value;
            return source;
        }

         public static TSource http_equiv<TSource>(this TSource source, string value) where TSource : meta
        {
            source.http_equiv = value;
            return source;
        }
    }
}
