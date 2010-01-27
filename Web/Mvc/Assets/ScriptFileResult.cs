using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.Assets
{
    public class ScriptFileResult : StaticFileResult
    {
        public ScriptFileResult(string filename) : base("text/javascript", filename, 30) { }
        public ScriptFileResult(string filename, int durationDays) : base("text/javascript", filename, durationDays) { }
    }
}
