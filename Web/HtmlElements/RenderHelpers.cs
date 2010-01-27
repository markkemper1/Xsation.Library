using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class OptionItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

    }

    public static class SelectHelper
    {
        public static string SelectWithOptions(select select, IEnumerable<OptionItem> options, string selectedValue)
        {
            return SelectWithOptions<OptionItem>(select, options, x => x.Value, y => y.Text, selectedValue);
        }

        public static string SelectWithOptions(select select, IDictionary<string, string> options, string selectedValue)
        {
            return SelectWithOptions<string>(select, options.Keys, x => x, y => options[y], selectedValue);
        }

        public static string SelectWithOptions<T>(select select, IEnumerable<T> items, Func<T, string> itemValue, Func<T, string> itemText, string selectedValue)
        {
            StringBuilder sb = new StringBuilder();
            select.RenderTo(sb);
            foreach (var o in items)
            {
                option option = new option() { value = itemValue(o) };
                option.selected = String.Compare(itemValue(o), selectedValue, false) == 0;
                option.RenderTo(sb);
                sb.Append(itemText(o));
                sb.Append(option.close);
            }
            sb.Append(select.close);
            return sb.ToString();
        }
    }

}
