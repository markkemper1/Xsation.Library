using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.MapUrl.Config
{
    public interface IMapUrlConfiguration
    {
        bool IsActive { get; set; }

        bool IsMapped(string url);

        string Map(string url);
    }
}
