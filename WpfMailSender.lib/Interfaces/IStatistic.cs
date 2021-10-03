using System;

namespace WpfMailSender.lib.Interfaces
{
    public interface IStatistic
    {
         int SendedMailsCount { get; }
        event EventHandler SendedMailsCountChanged;

        void MailSended();

        int SendersCount { get; }

        int RecipientsCount { get; }

        TimeSpan UpTime { get; }

        
    }
}
