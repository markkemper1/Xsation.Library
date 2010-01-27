using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public class script : element, ICharsetAttribute, ITypeAttribute, ISrcAttribute
    {
        /// <summary>
        ///     Defaults type to "text/javascript"
        /// </summary>
        public script() : base("script") { type = "text/javascript"; }

        public string charset
        {
            get { return this["charset"]; }
            set { this["charset"] = value; }
        }

        public string type
        {
            get { return this["type"]; }
            set { this["type"] = value; }
        }

        public string src
        {
            get { return this["src"]; }
            set { this["src"] = value; }
        }

        public static script open() { return new script(); }
        public static readonly string close = "</script>";

        internal override void SelfCloseTag()
        {
            throw new NotImplementedException("Cannot all selfClosing on a script element. This causes issues in some browsers");
        }

        public override void RenderTo(IRenderTo buffer)
        {
            base.RenderTo(buffer);

            if (!String.IsNullOrEmpty(this.src))
                buffer.Write("</script>");
        }
    }


}
