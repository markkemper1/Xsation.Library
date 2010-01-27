using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

using Xsation.Mvc.Helpers.HtmlElements;

namespace Xsation.Library.Web
{
    public static class ControlExtensions
    {
        
        public static string WhenTrue(this bool item, string html)
        {
            return item ? html : String.Empty;
        }

        public static string WhenFalse(this bool item, string html)
        {
            return item ? String.Empty : html;
        }

        public static string WhenEmpty(this string item, string whenEmptyHtml)
        {
            return String.IsNullOrEmpty(item) ? whenEmptyHtml : item;
        }
    }
}
