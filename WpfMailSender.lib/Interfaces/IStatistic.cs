﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib.Interfaces
{
    public interface IStatistic
    {
         int SendedMailsCount { get; }

        void MessageSended();

        int SendersCount { get; }

        int RecipientsCount { get; }

        TimeSpan UpTime { get; }

        
    }
}
