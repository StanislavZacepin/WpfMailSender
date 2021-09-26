using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib
{
    public class MailSenderService
    {
        public string ServerAddress {get; set; }
        public int ServerPort {get; set; }

        public bool UseSSL { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public void SendMessage(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            
        }
    }
}
