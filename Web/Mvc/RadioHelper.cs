using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xsation.Mvc.Helpers.HtmlElements;
using Xsation.Library.Web;

namespace Xsation.Web.Mvc
{
    public static class RadioHelper
    {
        public static radio radio(this xHtml xhtml, string name, string value)
        {
            var radio = new radio();
            radio.name = name;
            radio.value = value;

            if (xhtml.Context.ViewData.ModelState[name] == null || xhtml.Context.ViewData.ModelState[name].Value == null)
                return radio;

            radio.@checked = String.Compare(xhtml.Context.ViewData.ModelState[name].Value.AttemptedValue, value, true) == 0;

            return radio;
        }
    }
}
