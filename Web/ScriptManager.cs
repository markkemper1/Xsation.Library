using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Xsation.Mvc.Helpers.HtmlElements;
using Xsation.Mvc.Helpers.Urls;

namespace Xsation.Library.Web
{
    public class ScriptManager
    {
        private Dictionary<string, string> _scriptReference = new Dictionary<string, string>();
        private Dictionary<string, string> _scripts = new Dictionary<string, string>();
        private IResolveUrls _resolver;

        public ScriptManager(IResolveUrls resolver)
        {
            this._resolver = resolver;
        }

        public ScriptManager Add(string path)
        {
            if (this._scriptReference == null)
                throw new InvalidOperationException("TOO LATE!, Cannot add script, scripts have already been retrived");

            path = this._resolver.Resolve(path);

            if (this._scriptReference.ContainsKey(path))
                return this;

            this._scriptReference.Add(path, path);

            return this;
        }

        public ScriptManager Add(string key, string script)
        {
            if (this._scripts == null)
                throw new InvalidOperationException("TOO LATE!, Cannot add script, scripts have already been retrived");

            if (this._scripts.ContainsKey(key))
                return this;

            this._scripts.Add(key, script);

            return this;
        }

        public string[] GetReferenceScript()
        {
            var result = this._scriptReference.Values.ToArray();
            this._scriptReference = null;
            return result;
        }

        public string[] GetScripts()
        {
            var result = this._scripts.Values.ToArray();
            this._scripts = null;
            return result;
        }

        public string RenderTags()
        {
            StringBuilder sb = new StringBuilder();
            string[] referneceScripts = this.GetReferenceScript();
            string[] scripts = this.GetScripts();

            foreach (var rs in referneceScripts)
                new script() { src = rs }.RenderTo(sb);

            if (scripts.Length == 0)
                return sb.ToString();

            //Open script
            new script().RenderTo(sb);
            foreach (var s in scripts)
                sb.AppendLine(s);

            sb.Append(script.close);
            return sb.ToString();
        }
    }
}
