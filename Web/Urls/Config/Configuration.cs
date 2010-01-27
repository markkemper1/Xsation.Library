using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.Config
{
    using System.Configuration;


    public class Settings
    {
        public static IncludeConfiguration Current
        {
            get
            {
                return (IncludeConfiguration)ConfigurationManager.GetSection("Xsation.Mvc.Helpers.Includes");
            }
        }
    }

    public class IncludeConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("UrlMappings")]
        public IncludeSetCollection UrlMappings
        {
            get { return (IncludeSetCollection)this["UrlMappings"]; }
        }

        [ConfigurationProperty("Debug", IsRequired = true)]
        public bool Debug
        {
            get { return (bool)this["Debug"]; }
            set { this["Debug"] = value; }
        }
    }

    public class IncludeSetCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new IncludeElementCollection();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((IncludeElementCollection)element).Name;
        }
    }

    public class IncludeElementCollection : ConfigurationElementCollection
    {
        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["Name"]; }
        }

        [ConfigurationProperty("Url", IsRequired = true)]
        public string Url
        {
            get { return (string)this["Url"]; }
            set { this["Url"] = value; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new IncludeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((IncludeElement)element).IncludePath;
        }
    }

    public class IncludeElement : ConfigurationElement
    {
        [ConfigurationProperty("IncludePath", IsKey = true, IsRequired = true)]
        public string IncludePath
        {
            get { return (string)this["IncludePath"]; }
        }

    }

   
}
