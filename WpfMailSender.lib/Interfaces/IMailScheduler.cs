using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities;

namespace WpfMailSender.lib.Interfaces
{
    public interface IMailScheduler
    {
        event EventHandler TaskCompleted;

        bool Enable { get; set; }

        void Start();
        void Stop();

        SchedulerTask Plan(DateTime Time, Server server, Sender sender, IEnumerable<Recipient> recipients, Message message);
    }
}
