using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Threading;
using System.Web;

namespace Xsation.Library.Email
{
    public class FileSystemTemplateStorage : ITemplateStorage
    {

        ReaderWriterLock readWriteLock = new ReaderWriterLock();

        char[] invalids = Path.GetInvalidPathChars();
        XmlSerializer serializer = new XmlSerializer(typeof(FileSystemTemplate));

        public FileSystemTemplateStorage(string baseDir)
        {
            this.BaseDir = baseDir ?? (HttpContext.Current != null ? HttpContext.Current.Server.MapPath("~/App_Data/EmailTemplates") : null);
            if (this.BaseDir == null)
                throw new ArgumentNullException("You must specify a base directory for the FileSystemTemplate Storage constructors");
        }

        private string BaseDir { get; set; }

        public Template Load(string templateId)
        {
            using (var reader = new ReadLock(this.readWriteLock))
            {
                return this.Deserialize(this.GetFileName(templateId));
            }
        }

        public void Save(Template template)
        {
            using (var reader = new WriteLock(this.readWriteLock))
            {
                this.Serialize(template, this.GetFileName(template.Id));
            }
        }

        private string GetFileName(string templateId)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in templateId)
            {
                if (invalids.Contains(c))
                    sb.Append("-");
                else
                    sb.Append(c);
            }
            string filename = sb.ToString() + ".template";
            return Path.Combine(this.BaseDir, filename);
        }

        private Template Deserialize(string filename)
        {
            if (!File.Exists(filename))
                return null;

            using (FileStream stream = File.OpenRead(filename))
            {
                var fileTemplate = (FileSystemTemplate)serializer.Deserialize(stream);
                stream.Close();

                return new Template()
                {
                    Id = fileTemplate.Id,
                    SenderEmail = fileTemplate.SenderEmail,
                    SenderName = fileTemplate.SenderName,
                    Subject = fileTemplate.Subject,
                    BCC = new List<Recipient>(fileTemplate.BCC.Select(x => new Recipient(x.Email, x.Name))),
                    CC = new List<Recipient>(fileTemplate.CC.Select(x => new Recipient(x.Email, x.Name))),
                    BodyHtml = GetFileContent(filename, ".html"),
                    BodyText = GetFileContent(filename, ".txt")
                };
            }
        }

        private void Serialize(Template template, string filename)
        {
            var fileTemplate = new FileSystemTemplate()
            {
                Id = template.Id,
                SenderEmail = template.SenderEmail,
                SenderName = template.SenderName,
                Subject = template.Subject,
                BCC = template.BCC.Select(x => new FileSystemRecipient() { Email = x.Email, Name = x.Name }).ToArray(),
                CC = template.CC.Select(x => new FileSystemRecipient() { Email = x.Email, Name = x.Name }).ToArray(),
            };

            File.WriteAllText(filename + ".txt", template.BodyText);
            File.WriteAllText(filename + ".html", template.BodyHtml);

            using (FileStream stream = File.OpenWrite(filename))
            {
                serializer.Serialize(stream, fileTemplate);
                stream.Close();
            }

        }

        private string GetFileContent(string filename, string extension)
        {
            string bodyTextFilename = filename + extension;

            if (!File.Exists(bodyTextFilename))
                return null;

            return File.ReadAllText(bodyTextFilename);
        }

        [Serializable]
        [XmlRoot("EmailTemplate")]
        public class FileSystemTemplate
        {
            public string Id { get; set; }

            public string Subject { get; set; }

            public string SenderEmail { get; set; }

            public string SenderName { get; set; }

            [XmlArrayItem("Recipient")]
            public FileSystemRecipient[] CC { get; set; }

            [XmlArrayItem("Recipient")]
            public FileSystemRecipient[] BCC { get; set; }
        }

        [Serializable]
        public class FileSystemRecipient
        {
            public string Name { get; set; }

            public string Email { get; set; }
        }

        private class ReadLock : IDisposable
        {
            private ReaderWriterLock rwl;
            public ReadLock(ReaderWriterLock rwl)
            {
                this.rwl = rwl;
                rwl.AcquireReaderLock(0);
            }

            public void Dispose()
            {
                rwl.ReleaseReaderLock();
            }
        }

        private class WriteLock : IDisposable
        {
            private ReaderWriterLock rwl;
            public WriteLock(ReaderWriterLock rwl)
            {
                this.rwl = rwl;
                rwl.AcquireWriterLock(0);
            }

            public void Dispose()
            {
                rwl.ReleaseWriterLock();
            }
        }

    }


}
