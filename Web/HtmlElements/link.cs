using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class link : element, IRelAttribute,
        IRevAttribute, IHrefAttribute, ITypeAttribute,
        IMediaAttribute, ICharsetAttribute, ITargetAttribute
    {
        public link() : base("link") { this.SelfCloseTag(); }

        public string charset
        {
            get { return this["charset"]; }
            set { this["charset"] = value; }
        }

        public string href
        {
            get { return this["href"]; }
            set { this["href"] = value; }
        }

        public string rel
        {
            get { return this["rel"]; }
            set { this["rel"] = value; }
        }

        public string rev
        {
            get { return this["rev"]; }
            set { this["rev"] = value; }
        }

        public string target
        {
            get { return this["target"]; }
            set { this["target"] = value; }
        }

        public string media
        {
            get { return this["media"]; }
            set { this["media"] = value; }
        }

        public string type
        {
            get { return this["type"]; }
            set { this["type"] = value; }
        }
    }
}
