using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xsation.Library.Web;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public static class xHtmlExtensions
    {
        public static a a(this xHtml x) { return new a(); }
        public static img img(this xHtml x, string src, string alt) { return new img(src, alt); }
        public static label label(this xHtml x) { return new label(); }
        public static link link(this xHtml x) { return new link(); }
        public static script script(this xHtml x) { return new script(); }
        public static text text(this xHtml x, string text) { return new text(text); }
        public static select select(this xHtml x) { return new select(); }
        public static option option(this xHtml x) { return new option(); }
        public static textarea textarea(this xHtml x, int rows, int cols) { return new textarea(rows, cols); }
        public static button input_button(this xHtml x) { return new button(); }
        public static submit input_submit(this xHtml x) { return new submit(); }
        public static checkbox input_checkbox(this xHtml x) { return new checkbox(); }
        public static hidden input_hidden(this xHtml x) { return new hidden(); }
        public static imagebutton input_image(this xHtml x) { return new imagebutton(); }
        public static password input_password(this xHtml x) { return new password(); }
        public static radio input_radio(this xHtml x) { return new radio(); }
        public static reset input_reset(this xHtml x) { return new reset(); }
        public static textbox input_text(this xHtml x) { return new textbox(); }
    }
}
