using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class option : element, IDisabledAttribute, IValueAttribute
    {
        public option() : base("option") { }

        public static option open() { return new option(); }
        public static readonly string close = "</option>";

        public bool disabled
        {
            get { return this["disabled"] == "disabled"; }
            set { this["disabled"] = value ? "disabled" : null; }
        }

        public string label
        {
            get { return this["label"]; }
            set { this["label"] = value; }
        }

        public bool selected
        {
            get { return this["selected"] == "selected"; }
            set { this["selected"] = value ? "selected" : null; }
        }

        public string value
        {
            get { return this["value"]; }
            set { this["value"] = value; }
        }


        public static string RenderOptions(IEnumerable<OptionItem> options, string selectedValue)
        {
            StringBuilder sb = new StringBuilder();
            RenderOptionsTo<OptionItem>(sb, options, x => x.Value, y => y.Text, x => x.Title, selectedValue);
            return sb.ToString();
        }

        public static string RenderOptions(IEnumerable<string> options, string selectedValue)
        {
            return RenderOptions<string>(options, x => x, y => y, selectedValue);
        }

        public static string RenderOptions(IDictionary<string, string> options, string selectedValue)
        {
            return RenderOptions<string>(options.Keys, x => x, y => options[y], selectedValue);
        }

        public static string RenderOptions<T>(IEnumerable<T> items, Func<T, string> itemValue, Func<T, string> itemText, string selectedValue)
        {
            StringBuilder sb = new StringBuilder();
            RenderOptionsTo<T>(sb, items, itemValue, itemText, selectedValue);
            return sb.ToString();
        }

        public static void RenderOptionsTo<T>(StringBuilder sb, IEnumerable<T> items, Func<T, string> itemValue, Func<T, string> itemText, string selectedValue)
        {
            RenderOptionsTo<T>(sb, items, itemValue, itemText, x => null, selectedValue);
        }

        public static void RenderOptionsTo<T>(StringBuilder sb, IEnumerable<T> items, Func<T, string> itemValue, Func<T, string> itemText, Func<T, string> itemTitle, string selectedValue)
        {
            foreach (var o in items)
            {
                string title = itemTitle(o);
                option option = new option() { value = itemValue(o) };
                option.selected = String.Compare(itemValue(o), selectedValue, false) == 0;
                option.title = title == null ? null : title;
                option.RenderTo(sb);
                sb.Append(HttpUtility.HtmlEncode(itemText(o)));
                sb.Append(option.close);
            }
        }
    }

    public static class option_Extensions
    {
        public static TSource label<TSource>(this TSource source, string value) where TSource : option
        {
            source.label = value;
            return source;
        }

        public static TSource selected<TSource>(this TSource source, bool value) where TSource : option
        {
            source.selected = value;
            return source;
        }
    }
}
