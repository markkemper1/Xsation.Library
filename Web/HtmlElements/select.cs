using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class select : element, INameAttribute, IDisabledAttribute, ISizeAttribute
    {
        public select() : base("select") { }

        public static readonly string close = "</select>";

        public static select open() { return new select(); }

        public string name
        {
            get { return this["name"]; }
            set { this["name"] = value; }
        }

        public bool disabled
        {
            get { return this["disabled"] == "disabled"; }
            set { this["disabled"] = value ? "disabled" : null; }
        }

        public bool multiple
        {
            get { return this["multiple"] == "multiple"; }
            set { this["multiple"] = value ? "multiple" : null; }
        }

        public int? size
        {
            get { return String.IsNullOrEmpty(this["size"]) ? null : new int?(Convert.ToInt32(this["size"])); }
            set { this["size"] = value.HasValue ? value.Value.ToString() : null; }
        }
    }

    public static class select_Extensions
    {
        public static TSource multiple<TSource>(this TSource source, bool value) where TSource : select
        {
            source.multiple = value;
            return source;
        }
    }
}
