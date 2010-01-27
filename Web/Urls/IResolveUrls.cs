using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.Urls
{
    public interface IResolveUrls
    {
        string Resolve(string url);
    }
}
