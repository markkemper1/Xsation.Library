using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public interface IDisabledAttribute
    {
        bool disabled { get; set; }
    }

    public interface IReadonlyAttribute
    {
        bool @readonly { get; set; }
    }

    public interface INameAttribute
    {
        string name { get; set; }
    }

    public interface ISizeAttribute
    {
        int? size { get; set; }
    }

    public interface IHrefAttribute
    {
        string href { get; set; }
    }

    public interface IRelAttribute
    {
        string rel { get; set; }
    }

    public interface IRevAttribute
    {
        string rev { get; set; }
    }

    public interface ICharsetAttribute
    {
        string charset { get; set; }
    }

    public interface IMediaAttribute
    {
        string media { get; set; }
    }

    public interface ITypeAttribute
    {
        string type { get; set; }
    }

    public interface ISrcAttribute
    {
        string src { get; set; }
    }

    public interface ITargetAttribute
    {
        string target { get; set; }
    }

    public interface IAltAttribute
    {
        string alt { get; set; }
    }

    public interface IHeightAttribute
    {
        string height { get; set; }
    }

    public interface IWidthAttribute
    {
        string width { get; set; }
    }

    public interface IValueAttribute
    {
        string value { get; set; }
    }

    public interface ICheckedAttribute
    {
        bool @checked { get; set; }
    }
}
