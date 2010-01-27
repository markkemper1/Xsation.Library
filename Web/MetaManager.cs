using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xsation.Mvc.Helpers.HtmlElements;

namespace Xsation.Library.Web
{
    public class MetaManager
    {
        public string Description { get; set; }
        public string Keywords { get; set; }
        
        public MetaManager SetDescription(string description)
        {
            this.Description = description;
            return this;
        }

        public MetaManager SetKeywords(string keywords)
        {
            this.Keywords = keywords;
            return this;
        }

        public MetaManager PrependDescription(string description)
        {
            this.Description = description + this.Description;
            return this;
        }

        public MetaManager PrependKeywords(string keywords)
        {
            this.Keywords = keywords + this.Keywords;
            return this;
        }

        public MetaManager AppendDescription(string description)
        {
            this.Description = this.Description + description;
            return this;
        }

        public MetaManager AppendKeywords(string keywords)
        {
            this.Keywords = this.Keywords + keywords;
            return this;
        }

        public string RenderTags()
        {
            List<meta> tags = new List<meta>();

            if (!String.IsNullOrEmpty(this.Keywords))
                tags.Add(new meta() { name = "Description", content = this.Keywords });

            if (!String.IsNullOrEmpty(this.Description))
                tags.Add(new meta() { name = "Description", content = this.Description });

            if (tags.Count == 0)
                return String.Empty;

            return tags.RenderItems();
        }
    }
}
