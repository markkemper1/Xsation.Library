using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xsation.Mvc.Helpers.HtmlElements;
using Xsation.Library.Web;

namespace Xsation.Web.Mvc
{
    public static class General
    {
        public static string getValue(this xHtml xhtml, string name)
        {
            if (xhtml.Context.ViewData.ModelState[name] == null)
                return String.Empty;

            return xhtml.Context.ViewData.ModelState[name].Value.AttemptedValue;
        }

        public static string getValueEncoded(this xHtml xhtml, string name)
        {
            return xhtml.Encode(xhtml.getValue(name));
        }
         
    }
}
