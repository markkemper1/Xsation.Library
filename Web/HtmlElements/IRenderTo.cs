using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xsation.Mvc.Helpers.HtmlElements
{
    public interface IRenderTo
    {
        void Write(string text);
    }

    internal class StringBuilderRenderer : IRenderTo
    {
        public StringBuilderRenderer()
        {
            this.SB = new StringBuilder();
        }

        public StringBuilderRenderer(StringBuilder sb)
        {
            this.SB = sb;
        }

        private StringBuilder SB { get; set; }

        public void Write(string text)
        {
            this.SB.Append(text);
        }
    }

    internal class StreamWriterRenderer : IRenderTo
    {
        public StreamWriterRenderer(System.IO.StreamWriter writer)
        {
            this.SW = writer;
        }

        private System.IO.StreamWriter SW { get; set; }

        public void Write(string text)
        {
            this.SW.Write(text);
        }
    }
}
