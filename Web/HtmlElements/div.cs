using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class div : element
    {
        public div() : base("div") { }

        public static div open() { return new div(); }
        public static readonly string close = "</div>";
    }
}
