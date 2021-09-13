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
using TestWpfMailSender.Infrastructure.Services;
using TestWpfMailSender.Infrastructure.Services.InMemory;
using TestWpfMailSender.Models;
using TestWpfMailSender.ViewModels;
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

        public static IHostBuilder CreateHostBuilder(string[] Args) => Host
           .CreateDefaultBuilder(Args)
           .ConfigureAppConfiguration(opt => opt.AddJsonFile("settings.json", true, true))
           .ConfigureLogging(opt => opt.AddDebug())
           .ConfigureServices(ConfigureServices)
        ;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<IStatistic, InMemoryStatisticService>();

            services.AddSingleton<IMailService, DebugMailService>();

            services.AddSingleton<IRepository<Server>, InMemoryServersRepository>();
            services.AddSingleton<IRepository<Sender>, InMemorySendersRepository>();
            services.AddSingleton<IRepository<Recipient>, InMemoryRecipientsRepository>();
            services.AddSingleton<IRepository<Message>, InMemoryMessagesRepository>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Hosting.Start();
            base.OnStartup(e);

            //var services = new ServiceCollection();
            //services.AddScoped<MainWindowViewModel>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Hosting.Dispose();
        }
    }
}
