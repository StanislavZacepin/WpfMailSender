using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib.Interfaces
{
    public interface IMailService
    {
        void SendEmail(string From, string To, string Title, string Body);
    }
}
