using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{

    public abstract class input : element, IValueAttribute, INameAttribute, IDisabledAttribute
    {
        public input() : base("input") { this.SelfCloseTag(); }

        internal string type
        {
            get { return this["type"]; }
            set { this["type"] = value; }
        }

        public string value
        {
            get { return this["value"]; }
            set { this["value"] = value; }
        }

        public string name
        {
            get { return this["name"]; }
            set { this["name"] = value; }
        }

        public bool disabled
        {
            get { return this["disabled"] == "disabled"; }
            set { this["disabled"] = value ? "disabled" : null; }
        }
    }

    public class checkbox : input, ICheckedAttribute
    {
        public checkbox()
            : base()
        {
            this.type = "checkbox";
            this.value = "on";
        }

        public bool @checked
        {
            get { return this["checked"] == "checked"; }
            set { this["checked"] = value ? "checked" : null; }
        }
    }

    public class textbox : input, IReadonlyAttribute, ISizeAttribute
    {
        public textbox()
            : base()
        {
            this.type = "text";
        }

        public bool @readonly
        {
            get { return this["readonly"] == "readonly"; }
            set { this["readonly"] = value ? "readonly" : null; }
        }

        public int maxlength
        {
            get { return Convert.ToInt32(this["maxlength"]); }
            set { this["maxlength"] = value.ToString(); }
        }

        public int? size
        {
            get { return String.IsNullOrEmpty(this["size"]) ? null : new int?(Convert.ToInt32(this["size"])); }
            set { this["size"] = value.HasValue ? value.Value.ToString() : null; }
        }
    }

    public static class input_text_Extensions
    {
        public static TSource maxlength<TSource>(this TSource source, int value) where TSource : textbox
        {
            source.maxlength = value;
            return source;
        }
    }

    public class radio : checkbox
    {
        public radio()
            : base()
        {
            this.type = "radio";
        }
    }

    public class hidden : input
    {
        public hidden()
            : base()
        {
            this.type = "hidden";
        }
    }

    public class submit : input
    {
        public submit()
            : base()
        {
            this.type = "submit";
        }
    }

    public class reset : input
    {
        public reset()
            : base()
        {
            this.type = "reset";
        }
    }

    public class button : input
    {
        public button()
            : base()
        {
            this.type = "button";
        }
    }

    public class password : textbox
    {
        public password()
            : base()
        {
            this.type = "password";
        }
    }

    public class fileUpload : input
    {
        public fileUpload()
            : base()
        {
            this.type = "file";
        }
    }

    public class imagebutton : input, ISrcAttribute, IAltAttribute
    {
        public imagebutton()
            : base()
        {
            this.type = "image";
        }

        public string alt
        {
            get { return this["alt"]; }
            set { this["alt"] = value; }
        }

        public string src
        {
            get { return this["src"]; }
            set { this["src"] = value; }
        }
    }
}
