using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class a : element, IHrefAttribute, INameAttribute, IRelAttribute, IRevAttribute, ITargetAttribute
    {
        public a() : base("a") { }

        public static a open() { return new a(); }
        public static readonly string close = "</a>";

        public string href
        {
            get { return this["href"]; }
            set { this["href"] = value; }
        }

        public string name
        {
            get { return this["name"]; }
            set { this["name"] = value; }
        }

        public string rel
        {
            get { return this["rel"]; }
            set { this["rel"] = value; }
        }

        public string rev
        {
            get { return this["rev"]; }
            set { this["rev"] = value; }
        }

        public string target
        {
            get { return this["target"]; }
            set { this["target"] = value; }
        }

        public string shape
        {
            get { return this["shape"]; }
            set { this["shape"] = value; }
        }

        public string coords
        {
            get { return this["coords"]; }
            set { this["coords"] = value; }
        }
    }

    public static class a_Extensions
    {
        public static TSource shape<TSource>(this TSource source, string value) where TSource : a
        {
            source.shape = value;
            return source;
        }

        public static TSource coords<TSource>(this TSource source, string value) where TSource : a
        {
            source.coords = value;
            return source;
        }
    }
}
