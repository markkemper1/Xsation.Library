using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class li : element
    {
        public li() : base("li") { }

        public static li open() { return new li(); }
        public static readonly string close = "</li>";
    }
}
