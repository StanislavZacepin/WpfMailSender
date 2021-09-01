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
using TestWpfMailSender.ViewModels;

namespace TestWpfMailSender
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost __Hosting;

        public static IHost Hosting => __Hosting
            ??= CreatHostBulder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreatHostBulder(string[] args) => 
            Host.CreateDefaultBuilder(args).ConfigureAppConfiguration(opt => opt.AddJsonFile("appsettings.json",false, true))
            .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
        }
        
    }
}
