using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Xsation.Mvc.Helpers.Assets
{
    public class JpegResult : StaticFileResult
    {
        public JpegResult(string filename)
            : base("image/jpeg", filename, 30)
        { }
    }
}
