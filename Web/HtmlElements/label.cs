using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class label : element
    {
        public label() : base("label") { }

        public static label open() { return new label(); }
        public static readonly string close = "</label>";

        public string @for
        {
            get { return this["for"]; }
            set { this["for"] = value; }
        }
    }

    public static class label_Extensions
    {
        public static TSource @for<TSource>(this TSource source, string value) where TSource : label
        {
            source.@for = value;
            return source;
        }
    }
}
