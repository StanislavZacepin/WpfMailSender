using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestWpfMailSender.Infrastructure;
using TestWpfMailSender.Infrastructure.Services;
using TestWpfMailSender.Infrastructure.Services.InMemory;
using TestWpfMailSender.Models;
using TestWpfMailSender.ViewModels;
using WpfMailSender.lib;
using WpfMailSender.lib.Interfaces;
using WpfMailSender.lib.Services;

namespace TestWpfMailSender
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        private static IHost __Hosting;

        public static IHost Hosting => __Hosting
            ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] Args) => 
            Host.CreateDefaultBuilder(Args)
           .ConfigureAppConfiguration(opt => opt.AddJsonFile("appsettings.json", false, true))
           .ConfigureServices(ConfigureServices)
        ;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();         
            services.AddSingleton<StatisticViewModel>();         
                       

            services.AddSingleton<IRepository<Server>, ServersRepository>();
            services.AddSingleton<IRepository<Sender>, SendersRepository>();
            services.AddSingleton<IRepository<Recipient>, RecipientsRepository>();
            services.AddSingleton<IRepository<Message>, MessagesRepository>();

            services.AddSingleton<IStatistic, InMemoryStatisticService>();
#if DEBUG
            services.AddSingleton<IMailService, DebugMailService>();
#else
            services.AddSingleton<IMailService, SmtpMailService>();
#endif
        }

    }
}
