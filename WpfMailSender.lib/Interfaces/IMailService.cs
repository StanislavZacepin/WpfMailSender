﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib.Interfaces
{
   public interface IMailService
    {
        IMailSender GetSender(string Server, int Port, bool SSL, string Login, string Password);
    }
    public interface IMailSender
    {
        void Send(string SenderAddress, string RecipientAddress, string Subject, string Body);
        void Send(string SenderAddress, IEnumerable<string> RecipientsAddress, string Subject, string Body);
        void SendParallel(string SenderAddress, IEnumerable<string> RecipientsAddress, string Subject, string Body);
    }
}
