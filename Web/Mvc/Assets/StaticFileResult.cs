using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Xsation.Mvc.Helpers.Assets
{
    public class StaticFileResult : FileResult
    {
        public StaticFileResult(string contentType, string filename, int durationDays) : base(contentType)
        {
            this.FileName = filename;
            this.DurationDays = durationDays;
        }

        public string FileName{ get; set; }
        
        public int DurationDays { get; set; }


        protected override void WriteFile(HttpResponseBase response)
        {
            if (!File.Exists(this.FileName))
            {
                response.StatusCode = 404;
                response.End();
                return;
            }
            response.ContentType = this.ContentType;
            response.AddFileDependency(this.FileName);
            response.Cache.SetETagFromFileDependencies();
            response.Cache.SetLastModifiedFromFileDependencies();
            response.Cache.SetValidUntilExpires(true);
            response.Cache.SetExpires(DateTime.Now.AddDays(this.DurationDays));
            response.Cache.SetCacheability(HttpCacheability.Public);
            response.TransmitFile(this.FileName);
        }
    }
}
