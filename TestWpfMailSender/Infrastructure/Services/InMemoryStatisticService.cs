using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWpfMailSender.Data;
using WpfMailSender.lib.Interfaces;

namespace TestWpfMailSender.Infrastructure.Services
{
    internal class InMemoryStatisticService : IStatistic
    {
         
        private int _SendedMailsCount;

        public int SendedMailsCount => _SendedMailsCount;
        public event EventHandler SendedMailsCountChanged;

        public int SendersCount => TestData.Senders.Count;
        public int RecipientsCount => TestData.Recipients.Count;


        private readonly Stopwatch _Timer = Stopwatch.StartNew();
        public TimeSpan UpTime => _Timer.Elapsed;

        public void MailSended()
        {
            _SendedMailsCount++;
            SendedMailsCountChanged?.Invoke(this, EventArgs.Empty);
        }

       
    }
}