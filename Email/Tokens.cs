using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Library
{
    public class Tokens : Dictionary<string, string>
    {
        public Tokens()
        {
        }

        public Tokens(string key, string value)
        {
            this.Add(key, value);
        }

        public Tokens Set(string key, string value)
        {
            if (this.ContainsKey(key))
                this[key] = value;

            this.Add(key, value);

            return this;
        }
    }
}
