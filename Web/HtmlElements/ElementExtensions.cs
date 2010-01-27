using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public static class element_Extensions
    {
        public static TSource attr<TSource>(this TSource source, string name, string value) where TSource : element
        {
            source[name] = value;
            return source;
        }

        public static TSource id<TSource>(this TSource source, string value) where TSource : element
        {
            source.id = value;
            return source;
        }

        public static TSource title<TSource>(this TSource source, string value) where TSource : element
        {
            source.title = value;
            return source;
        }

        public static TSource style<TSource>(this TSource source, string value) where TSource : element
        {
            source.style = value;
            return source;
        }

        public static TSource @class<TSource>(this TSource source, string value) where TSource : element
        {
            source.@class = value;
            return source;
        }

        public static TSource accesskey<TSource>(this TSource source, string value) where TSource : element
        {
            source.accesskey = value;
            return source;
        }

        public static TSource tabindex<TSource>(this TSource source, string value) where TSource : element
        {
            source.tabindex = value;
            return source;
        }

        public static TSource SelfClose<TSource>(this TSource source) where TSource : element
        {
            source.SelfCloseTag();
            return source;
        }


        public static string RenderItems<TSource>(this IEnumerable<TSource> items) where TSource : element
        {
            StringBuilder sb = new StringBuilder();
            foreach (var e in items)
                e.RenderTo(sb);
            return sb.ToString();
        }
    }
}
