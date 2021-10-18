using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Interfaces;

namespace TestWpfMailSender.ViewModels
{
    internal class SchedulerViewModel
    {
        private readonly IMailScheduler _Scheduler;

        public SchedulerViewModel(IMailScheduler Scheduler) => _Scheduler = Scheduler;

    }
}
