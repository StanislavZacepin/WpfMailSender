using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfMailSender.Models
{
    // для планировщика
    public class SchedulerTask
    {
        public DateTime Time { get; set; }
        public Server Server { get; set; }// сервер который надо будет отправить что нибудь
        public Sender Sender { get; set; }
        public List<Recipient> Recipient { get; set; }
        public Message Message { get; set; }
    }
}
