using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class form : element
    {
        public form(string action) : base("form") { this.action = action; }

        public string action
        {
            get { return this["action"]; }
            set { this["action"] = value; }
        }

        public string method
        {
            get { return this["method"]; }
            set { this["method"] = value; }
        }

        public form Post()
        {
            this.method = "post";
            return this;
        }

        public static form open(string action) { return new form(action); }
        public static readonly string close = "</form>";
    }


    public static class form_Extensions
    {
        public static TSource action<TSource>(this TSource source, string value) where TSource : form
        {
            source.action = value;
            return source;
        }

        public static TSource method<TSource>(this TSource source, string value) where TSource : form
        {
            source.method = value;
            return source;
        }
    }
}
