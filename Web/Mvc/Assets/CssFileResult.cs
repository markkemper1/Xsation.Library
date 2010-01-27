using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.Assets
{
    public class CssFileResult : StaticFileResult
    {
        public CssFileResult(string filename) : base("text/css", filename, 30) { }
        public CssFileResult(string filename, int durationDays) : base("text/javascript", filename, durationDays) { }
    }
}
