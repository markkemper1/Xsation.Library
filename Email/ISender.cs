using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Xsation.Library
{
    public interface ISender
    {
        void Send(MailMessage message);
    }
}
