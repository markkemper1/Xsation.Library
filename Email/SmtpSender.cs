using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Xsation.Library
{
    /// <summary>
    ///     Simple sender that just uses a smptclient to send the message.
    /// </summary>
    public class SmtpSender : ISender
    {
        public SmtpSender()
            : this(new SmtpClient())
        {
        }

        public SmtpSender(SmtpClient client)
        {
            this.Client = client;
        }

        private SmtpClient Client { get; set; }

        public void Send(MailMessage message)
        {
            this.Client.Send(message);
        }
    }
}
