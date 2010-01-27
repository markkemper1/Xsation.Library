using System;
using System.Text;
using Xsation.Mvc.Helpers.HtmlElements;
using System.Web.Mvc;
using Xsation.Library.Web;

namespace Xsation.Web.Mvc
{
    public static class TextboxHelper
    {
        public static textbox textbox(this xHtml xhtml, string name)
        {
            var textbox = new textbox();
            textbox.name= name;

            textbox.value = xhtml.inputValue(name);
            
            return textbox;
        }

        public static textbox textbox(this xHtml xhtml, string name, string value)
        {
            var textbox = new textbox();
            textbox.name = name;
            textbox.value = xhtml.inputValue(name) ?? value;

            return textbox;
        }

        public static string inputValue(this xHtml xhtml, string name)
        {

            if (xhtml.Context.ViewData.ModelState[name] == null)
                return null;

            if (xhtml.Context.ViewData.ModelState[name].Value == null)
                return null;

            return xhtml.Context.ViewData.ModelState[name].Value.AttemptedValue;
        }
    }
}
