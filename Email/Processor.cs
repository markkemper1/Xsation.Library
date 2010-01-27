using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Xsation.Library
{
    public class Processor
    {
        public Processor(ISender sender)
        {
            this.Sender = sender ?? new SmtpSender();
        }

        public ISender Sender { get; set; }

        public void Send(MailMessage message)
        {
            this.Sender.Send(message);
        }

        public void Send(Template template, string email)
        {
            this.SendInternal(template, new Recipient(email));
        }

        public void Send(Template template, string email, string name)
        {
            this.SendInternal(template, new Recipient(email, name));
        }

        public void Send(Template template, Recipient to)
        {
            this.SendInternal(template, to);
        }

        public void Send(Template template, IEnumerable<Recipient> to)
        {
            foreach (var r in to)
                this.SendInternal(template, r);
        }

        private void SendInternal(Template template, Recipient r)
        {
            template = template.Copy();

            MailMessage m = new MailMessage();

            m.To.Add(new MailAddress(r.Email, r.Name));
            m.From = new MailAddress(template.SenderEmail, template.SenderName);
            m.Subject = this.ReplaceTokens(template.Subject, r.Tokens);

            m.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");

            string bodyText = this.ReplaceTokens(template.BodyText, r.Tokens);
            string bodyHtml = this.ReplaceTokens(template.BodyHtml, r.Tokens);

            //check for plain text body
            if (String.IsNullOrEmpty(bodyHtml))
                m.Body = bodyText;
            else
            {
                //Set body text to to a stripped version of the html text if its empty
                bodyText = !String.IsNullOrEmpty(bodyText) ? bodyText : Regex.Replace(bodyHtml, @"<(.|\n)*?>", String.Empty);

                var plainView = AlternateView.CreateAlternateViewFromString(bodyText, null, "text/plain");
                var htmlView = AlternateView.CreateAlternateViewFromString(bodyHtml, null, "text/html");

                m.AlternateViews.Add(plainView);
                m.AlternateViews.Add(htmlView);
            }
            
            this.AddAddress(template.BCC, m.Bcc);
            this.AddAddress(template.CC, m.CC);

            this.Sender.Send(m);
        }

        private string ReplaceTokens(string text, IDictionary<string, string> tokens)
        {
            if (tokens == null)
                return text;

            foreach (var t in tokens)
                text = text.Replace(t.Key, t.Value);

            return text;
        }

        private void AddAddress(IList<Recipient> list, MailAddressCollection mailAddress)
        {
            foreach (var r in list)
            {
                mailAddress.Add(new MailAddress(r.Email, r.Name));
            }
        }
    }
}
