using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public abstract class element
    {
        private string _name;
        private bool _selfClosing;
        private Dictionary<string, string> _attributes = new Dictionary<string, string>();

        public element(string name)
        {
            this._name = name;
            this._selfClosing = false;
        }

        public string id
        {
            get { return this["id"]; }
            set { this["id"] = value; }
        }

        public string title
        {
            get { return this["title"]; }
            set { this["title"] = value; }
        }

        public string @class
        {
            get { return this["class"]; }
            set { this["class"] = value; }
        }

        public string style
        {
            get { return this["style"]; }
            set { this["style"] = value; }
        }

        public string accesskey
        {
            get { return this["accesskey"]; }
            set { this["accesskey"] = value; }
        }

        public string tabindex
        {
            get { return this["tabindex"]; }
            set { this["tabindex"] = value; }
        }

        public string ToHtml()
        {
            return this.ToString();
        }

        protected string innerHtml { get; set; }

        internal string this[string index]
        {
            get
            {
                if (!this._attributes.ContainsKey(index))
                    return String.Empty;

                return this._attributes[index];
            }
            set
            {
                if (this._attributes.ContainsKey(index))
                    this._attributes[index] = value;
                else
                    this._attributes.Add(index, value);
            }
        }

        internal virtual void SelfCloseTag()
        {
            this._selfClosing = true;
        }

        public string Name { get { return this._name; } }

        private element Add(string name, string value)
        {
            this._attributes.Add(name, value);
            return this;
        }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            this.RenderTo(sb);
            return sb.ToString();
        }

        public void RenderTo(StringBuilder sb)
        {
            RenderTo(new StringBuilderRenderer(sb));
        }

        public void RenderTo(StreamWriter sw)
        {
            RenderTo(new StreamWriterRenderer(sw));
        }

        public virtual void RenderTo(IRenderTo buffer)
        {
            buffer.Write("<");
            buffer.Write(this._name);
            buffer.Write(" ");

            foreach (var pair in this._attributes)
            {
                if (String.IsNullOrEmpty(pair.Value))
                    continue;

                buffer.Write(pair.Key);
                buffer.Write("=\"");
                buffer.Write(HttpUtility.HtmlAttributeEncode(pair.Value));
                buffer.Write("\" ");
            }

            if (this._selfClosing)
                buffer.Write("/");

            buffer.Write(">");
        }

        public override string ToString()
        {
            return this.Render();
        }
    }
}
