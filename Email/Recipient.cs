using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Library
{
    public class Recipient
    {
        public Recipient(string email)
            : this(email, null)
        { }

        public Recipient(string email, string name)
        {
            this.Email = email;
            this.Name = name;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public IDictionary<string, string> Tokens { get; set; }
    }
}
