using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class text
    {
        public text(string value)
        {
            this.value = value;
        }

        public string value { get; set; }

        public void Append(StringBuilder sb)
        {
            sb.Append(this.ToString());
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(this.value))
                return String.Empty;

            return System.Web.HttpUtility.HtmlEncode(this.value);
        }
    }
}
