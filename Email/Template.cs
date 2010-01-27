using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Library
{
    public class Template : ICloneable
    {
        public Template()
        {
            this.CC = new List<Recipient>();
            this.BCC = new List<Recipient>();
        }

        public string Id { get; set; }

        public string SenderName { get; set; }

        public string SenderEmail { get; set; }

        public IList<Recipient> CC { get; set; }

        public IList<Recipient> BCC { get; set; }

        public string Subject { get; set; }

        public string BodyText { get; set; }

        public string BodyHtml { get; set; }

        public object Clone()
        {
            var clone = (Template)this.MemberwiseClone();
            clone.CC = new List<Recipient>(this.CC);
            clone.BCC = new List<Recipient>(this.BCC);
            return clone;
        }

        public Template Copy()
        {
            return (Template)this.Clone();
        }
    }
}
