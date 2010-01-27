using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using Xsation.Mvc.Helpers.HtmlElements;
using System.Web.Mvc;
using Xsation.Mvc.Helpers.Config;
using Xsation.Mvc.Helpers.Urls;
using Xsation.Library;
using Xsation.Mvc.Helpers;

namespace Xsation.Library.Web
{
    public static class xHtmlExtensions
    {
        
        public static IResolveUrls Resolver = new MappedUrlResolver(new UrlResolver(), new IncludeConfig(Settings.Current));

        public static xHtml xhtml(this ViewUserControl control)
        {
            return control.ViewContext.GetContextInstance<xHtml>("xHtml", () => new xHtml(control, control.ViewContext, xHtmlExtensions.Resolver));
        }

        public static xHtml xhtml(this ViewPage control)
        {
            return control.ViewContext.GetContextInstance<xHtml>("xHtml", () => new xHtml(control, control.ViewContext, xHtmlExtensions.Resolver));
        }

        public static xHtml xhtml(this ViewMasterPage control)
        {
            return control.ViewContext.GetContextInstance<xHtml>("xHtml", () => new xHtml(control, control.ViewContext, xHtmlExtensions.Resolver));
        }

        public static T GetContextInstance<T>(this ViewContext context, string key, Func<T> createObject)
        {
            var item = context.HttpContext.Items[key];

            if (item != null)
                return (T)item;

            T t = createObject();
            context.HttpContext.Items[key] = t;
            return t;
        }

    }

    public class xHtml
    {
        public xHtml(Control control, ViewContext context, IResolveUrls resolver)
        {
            this.Head = new xHtmlHeader(resolver);
            this.Body = new xHtmlBody(resolver);
            this.Context = context;
            this.Urls = resolver;
        }

        public readonly IResolveUrls Urls;

        public readonly ViewContext Context;

        public readonly xHtmlHeader Head;
        
        public readonly xHtmlBody Body;

        public string Encode(string text)
        {
            return System.Web.HttpUtility.HtmlEncode(text);
        }

        public img Image(string url, string altText, int width, int height)
        {
            return new img(this.Urls.Resolve(url), altText) { width = width.ToString(), height = height.ToString() };
        }
    }

    public class xHtmlHeader
    {
        internal xHtmlHeader(IResolveUrls resolver)
        {
            this.Script = new ScriptManager(resolver);
            this.Css = new CssManager(resolver);
            this.Meta = new MetaManager();
        }

        public string Title {get;set;}
        public readonly MetaManager Meta;
        public readonly ScriptManager Script;
        public readonly CssManager Css;


        public xHtmlHeader SetTitle(string title)
        {
            this.Title = title;
            return this;
        }


        public xHtmlHeader AppendTitle(string title)
        {
            this.Title = this.Title + title;
            return this;
        }

        public xHtmlHeader PrependTitle(string title)
        {
            this.Title = title + this.Title;
            return this;
        }

    }

    public class xHtmlBody
    {
        internal xHtmlBody(IResolveUrls resolver)
        {
            this.Script = new ScriptManager(resolver); ;
        }

        public readonly ScriptManager Script;
    }
}
