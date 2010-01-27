using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class img : element, ISrcAttribute, IAltAttribute, IHeightAttribute, IWidthAttribute
    {
        public img(string src, string alt)
            : base("img")
        {
            this.SelfCloseTag();
            this.alt = alt;
            this.src = src;
        }

        public string src
        {
            get { return this["src"]; }
            set { this["src"] = value; }
        }

        public string alt
        {
            get { return this["alt"]; }
            set { this["alt"] = value; }
        }

        public string height
        {
            get { return this["height"]; }
            set { this["height"] = value; }
        }

        public string width
        {
            get { return this["width"]; }
            set { this["width"] = value; }
        }

        public string longdesc
        {
            get { return this["longdesc"]; }
            set { this["longdesc"] = value; }
        }

        public string usemap
        {
            get { return this["usemap"]; }
            set { this["usemap"] = value; }
        }
    }

    public static class img_Extensions
    {
        public static TSource longdesc<TSource>(this TSource source, string value) where TSource : img
        {
            source.longdesc = value;
            return source;
        }

        public static TSource usemap<TSource>(this TSource source, string value) where TSource : img
        {
            source.usemap = value;
            return source;
        }

    }
}
