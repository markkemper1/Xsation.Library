using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Library
{
    public interface ITemplateStorage
    {
        Template Load(string templateId);

        void Save(Template template);
    }
}
