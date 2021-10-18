using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfMailSender.ViewModels
{
   internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel
        {
            get
            {
                var model = App.Services.GetRequiredService<MainWindowViewModel>();
                return model;
            }
        }

        public StatisticViewModel Statistic => App.Services.GetRequiredService<StatisticViewModel>();

        public SchedulerViewModel SchedulerModel => App.Services.GetRequiredService<SchedulerViewModel>();
    }
}
