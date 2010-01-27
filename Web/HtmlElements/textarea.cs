using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class textarea : element, INameAttribute, IReadonlyAttribute, IDisabledAttribute
    {
        public textarea(int rows, int cols)
            : base("textarea")
        {
            this.rows = rows;
            this.cols = cols;
        }

        public static textarea open(int rows, int cols) { return new textarea(rows, cols); }
        public static readonly string close = "</textarea>";

        public int rows
        {
            get { return Convert.ToInt32(this["rows"]); }
            set { this["rows"] = value.ToString(); }
        }

        public int cols
        {
            get { return Convert.ToInt32(this["cols"]); }
            set { this["cols"] = value.ToString(); }
        }

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

        public bool @readonly
        {
            get { return this["readonly"] == "readonly"; }
            set { this["readonly"] = value ? "readonly" : null; }
        }
    }

    public static class textarea_Extensions
    {
        public static TSource rows<TSource>(this TSource source, int value) where TSource : textarea
        {
            source.rows = value;
            return source;
        }

        public static TSource cols<TSource>(this TSource source, int value) where TSource : textarea
        {
            source.cols = value;
            return source;
        }
    }
}
