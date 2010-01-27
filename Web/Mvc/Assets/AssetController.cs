using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Xsation.Mvc.Helpers.Assets
{
    public class AssetController : Controller
    {
        public ScriptFileResult Script(string path)
        {
            string filename = this.Server.MapPath(path);
            return new ScriptFileResult(filename);
        }

        public CssFileResult Css(string path)
        {
            string filename = this.Server.MapPath(path);
            return new CssFileResult(filename);
        }
    }
}
