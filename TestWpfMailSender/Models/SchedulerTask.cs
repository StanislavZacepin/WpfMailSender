using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWpfMailSender.Models.Base;

namespace TestWpfMailSender.Models
{
    // для планировщика
    public class SchedulerTask : Entity
    {
        public DateTime Time { get; set; } = DateTime.Now;
        [Required]
        public Server Server { get; set; }// сервер который надо будет отправить что нибудь
        [Required]
        public Sender Sender { get; set; }
        
        public ICollection<Recipient> Recipient { get; set; }
        [Required]
        public Message Message { get; set; }
    }
}
