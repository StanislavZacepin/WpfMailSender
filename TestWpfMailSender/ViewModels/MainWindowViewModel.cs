using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestWpfMailSender.Infrastructure;
using TestWpfMailSender.Models;
using WpfMailSender.lib.Commands;
using WpfMailSender.lib.Interfaces;
using WpfMailSender.lib.ViewModels.Base;

namespace TestWpfMailSender.ViewModels
{
   internal class MainWindowViewModel : ViewModel
    {
        private readonly ServersRepository _Servers;
        private readonly IMailService _MailService;
        private string _Title = "Рассыльщик";
        public string Title { get => _Title; set => Set(ref _Title, value); }


        private string _Status = "Готов!";
        public string Status { get => _Status; set => Set(ref _Status, value); }

        public ObservableCollection<Server> Servers { get; } = new ();

        #region Команды
        private ICommand _LoadServersCommand;
        public ICommand LoadServersCommand => _LoadServersCommand
            ??= new LambdaCommand(OnLoadServersCommandExecute, CanLoadServersCommandExecute);
        private bool CanLoadServersCommandExecute(object p) => Servers.Count == 0;
        private void OnLoadServersCommandExecute(object p)
        {
            LoadServers();
            
        }

        #endregion 
        #region Send
        private ICommand _SendEmailCommand;
        public ICommand SendEmailCommand => _SendEmailCommand
            ??= new LambdaCommand(OnSendServersCommandExecute, CanSendServersCommandExecute);
        private bool CanSendServersCommandExecute(object p) => Servers.Count == 0;
        private void OnSendServersCommandExecute(object p)
        {
            _MailService.SendEmail("Иванов", "Петров", "Тема", "Тело Письма");

        }

#endregion
        public MainWindowViewModel(ServersRepository Servers, IMailService MailService)
        {
            _Servers = Servers;
            _MailService = MailService;
        }

        private void LoadServers()
        {
            foreach (var server in _Servers.GetAll())
                Servers.Add(server);
           
        }

    }
}
