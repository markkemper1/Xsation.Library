using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public static class InterfaceExtensions
    {
        public static TSource src<TSource>(this TSource source, string value) where TSource : ISrcAttribute
        {
            source.src = value;
            return source;
        }

        public static TSource alt<TSource>(this TSource source, string value) where TSource : IAltAttribute
        {
            source.alt = value;
            return source;
        }

        public static TSource height<TSource>(this TSource source, string value) where TSource : IHeightAttribute
        {
            source.height = value;
            return source;
        }

        public static TSource width<TSource>(this TSource source, string value) where TSource : IWidthAttribute
        {
            source.width = value;
            return source;
        }

        public static TSource value<TSource>(this TSource source, string value) where TSource : IValueAttribute
        {
            source.value = value;
            return source;
        }

        public static TSource name<TSource>(this TSource source, string value) where TSource : INameAttribute
        {
            source.name = value;
            return source;
        }

        public static TSource disabled<TSource>(this TSource source, bool value) where TSource : IDisabledAttribute
        {
            source.disabled = value;
            return source;
        }

        public static TSource @checked<TSource>(this TSource source, bool value) where TSource : ICheckedAttribute
        {
            source.@checked = value;
            return source;
        }

        public static TSource rel<TSource>(this TSource source, string value) where TSource : IRelAttribute
        {
            source.rel = value;
            return source;
        }

        public static TSource rev<TSource>(this TSource source, string value) where TSource : IRevAttribute
        {
            source.rev = value;
            return source;
        }

        public static TSource charset<TSource>(this TSource source, string value) where TSource : ICharsetAttribute
        {
            source.charset = value;
            return source;
        }

        public static TSource href<TSource>(this TSource source, string value) where TSource : IHrefAttribute
        {
            source.href = value;
            return source;
        }

        public static TSource target<TSource>(this TSource source, string value) where TSource : ITargetAttribute
        {
            source.target = value;
            return source;
        }
    }
}
