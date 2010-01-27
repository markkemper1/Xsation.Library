using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Xsation.Library.Email
{
    public class EmalService
    {
        /// <summary>
        ///     Constructs a email service, you can pass null for arguments and defaults will be used. 
        ///     Otherwise pass in your own implemeations.
        /// </summary>
        /// <param name="processor">The processor actuallly does the sending of the emails</param>
        /// <param name="storage">A template storage provider.</param>
        public EmalService(Processor processor, ITemplateStorage storage)
        {
            this.Processor = processor ?? new Processor(null);
            this.Storage = storage ?? new FileSystemTemplateStorage(null);
        }

        public ITemplateStorage Storage { get; set; }

        public Processor Processor { get; set; }

        public void Send(MailMessage message)
        {
            this.Processor.Send(message);
        }

        public void Send(string templateId, string email)
        {
            this.Processor.Send(this.Storage.Load(templateId), email);
        }

        public void Send(string templateId, string email, IDictionary<string, string> tokens)
        {
            var recipient = new Recipient(email) { Tokens = tokens };
            this.Processor.Send(this.Storage.Load(templateId), recipient);
        }

        public void Send(string templateId, string email, string name)
        {
            this.Processor.Send(this.Storage.Load(templateId), email, name);
        }

        public void Send(string templateId, string email, string name, IDictionary<string, string> tokens)
        {
            var recipient = new Recipient(email, name) { Tokens = tokens };
            this.Processor.Send(this.Storage.Load(templateId), recipient);
        }

        public void Send(string templateId, Recipient to)
        {
            this.Processor.Send(this.Storage.Load(templateId), to);
        }

        public void Send(string templateId, IEnumerable<Recipient> to)
        {
            this.Processor.Send(this.Storage.Load(templateId), to);
        }
    }
}
