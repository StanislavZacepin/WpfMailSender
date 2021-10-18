using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestWpfMailSender.Data;
using TestWpfMailSender.Infrastructure;
using TestWpfMailSender.Infrastructure.Services;
using TestWpfMailSender.Infrastructure.Services.InDatabase;
using TestWpfMailSender.Infrastructure.Services.InMemory;
using TestWpfMailSender.ViewModels;
using WpfMailSender.lib;
using WpfMailSender.lib.Entities;
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
            services.AddDbContext<MailSenderDB>(opt => opt.UseSqlServer(host.Configuration.GetConnectionString("SqlServer")));
            services.AddTransient<DbInitializer>();

            services.AddSingleton<MainWindowViewModel>();         
            services.AddSingleton<StatisticViewModel>();
            services.AddScoped<SchedulerViewModel>();


            #region репозиторий  Тест данных без sql базы данных
            //services.AddSingleton<IRepository<Server>, ServersRepository>();
            //services.AddSingleton<IRepository<Sender>, SendersRepository>();
            //services.AddSingleton<IRepository<Recipient>, RecipientsRepository>();
            //services.AddSingleton<IRepository<Message>, MessagesRepository>(); 
            #endregion
            #region Репозитории тест данных  с помощью Sql базы данных
            //services.AddScoped<IRepository<Server>, DbRepository<Server>>();
            //services.AddScoped<IRepository<Sender>, DbRepository<Sender>>();
            //services.AddScoped<IRepository<Recipient>, DbRepository<Recipient>>();
            //services.AddScoped<IRepository<Message>, DbRepository<Message>>();
            //services.AddScoped<IRepository<SchedulerTask>, DbRepository<SchedulerTask>>(); 

            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));  // Подставляет сущности автоматически. чтобы не писать каждую отдельно


            services.AddScoped<IMailScheduler, MailSchedulerService>();
            #endregion

            services.AddSingleton<IStatistic, InMemoryStatisticService>();
#if DEBUG
            services.AddSingleton<IMailService, DebugMailService>();
#else
            services.AddSingleton<IMailService, SmtpMailService>();
#endif
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using(var scope = Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
                initializer.InitializerAsync().Wait();
            }

            base.OnStartup(e);
        }
    }
}
