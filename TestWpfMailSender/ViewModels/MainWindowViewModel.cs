using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestWpfMailSender.Infrastructure.Services.InMemory;
using WpfMailSender.lib.Commands;
using WpfMailSender.lib.Entities;
using WpfMailSender.lib.Entities.Base;
using WpfMailSender.lib.Interfaces;
using WpfMailSender.lib.ViewModels.Base;

namespace TestWpfMailSender.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Server> _Servers;
        private readonly IRepository<Sender> _Senders;
        private readonly IRepository<Recipient> _Recipients;
        private readonly IRepository<Message> _Messages;


        private readonly IMailService _MailService;

        private string _Title = "Рассыльщик";

        public string Title { get => _Title; set => Set(ref _Title, value); }

        private string _Status = "Готов!";

        public string Status { get => _Status; set => Set(ref _Status, value); }

        public ObservableCollection<Server> Servers { get; } = new();
        public ObservableCollection<Recipient> Recipients { get; } = new();
        public ObservableCollection<Sender> Senders { get; } = new();
        public ObservableCollection<Message> Messages { get; } = new();

        #region Команды

        #region SelectedRecipient : Recipient - Выбранный получатель

        /// <summary>Выбранный получатель</summary>
        private Recipient _SelectedRecipient;

        /// <summary>Выбранный получатель</summary>
        public Recipient SelectedRecipient { get => _SelectedRecipient; set => Set(ref _SelectedRecipient, value); }

        #endregion

        #region SelectedSender : Sender - Выбранный отправитель

        /// <summary>Выбранный отправитель</summary>
        private Sender _SelectedSender;

        /// <summary>Выбранный отправитель</summary>
        public Sender SelectedSender { get => _SelectedSender; set => Set(ref _SelectedSender, value); }

        #endregion

        #region SelectedServer : Server - Выбранный сервер

        /// <summary>Выбранный сервер</summary>
        private Server _SelectedServer;

        /// <summary>Выбранный сервер</summary>
        public Server SelectedServer { get => _SelectedServer; set => Set(ref _SelectedServer, value); }

        #endregion

        #region SelectedMessage : Message - Выбранное сообщение

        /// <summary>Выбранное сообщение</summary>
        private Message _SelectedMessage;

        /// <summary>Выбранное сообщение</summary>
        public Message SelectedMessage { get => _SelectedMessage; set => Set(ref _SelectedMessage, value); }

        #endregion

        private ICommand _LoadServersCommand;

        public ICommand LoadDataCommand => _LoadServersCommand
            ??= new LambdaCommand(OnLoadServersCommandExecuted, CanLoadServersCommandExecute);

        private bool CanLoadServersCommandExecute(object p) => Servers.Count == 0;

        private void OnLoadServersCommandExecuted(object p)
        {
            LoadData();
        }

        private ICommand _SendEmailCommand;

        public ICommand SendEmailCommand => _SendEmailCommand
            ??= new LambdaCommand(OnSendEmailCommandExecuted, CanSendEmailCommandExecute);

        private bool CanSendEmailCommandExecute(object p) => Servers.Count == 0;

        private void OnSendEmailCommandExecuted(object p)
        {
            

            var sender = _MailService.GetSender("smtp.yandex", 25, true, "login", "password");
            sender.Send("Иванов", "Петров", "Тема", "Тело письма");
        }

        #endregion

        public MainWindowViewModel(
            IRepository<Server> Servers,
            IRepository<Sender> Senders,
            IRepository<Recipient> Recipients,
            IRepository<Message> Messages,
            IMailService MailService)
        {
            _Servers = Servers;
            _Senders = Senders;
            _Recipients = Recipients;
            _Messages = Messages;

            _MailService = MailService;
        }

        private static void Load<T>(ObservableCollection<T> collection, IRepository<T> rep) where T : Entity
        {
            collection.Clear();
            foreach (var item in rep.GetAll())
                collection.Add(item);
        }

        private void LoadData()
        {
            Load(Servers, _Servers);
            Load(Recipients, _Recipients);
            Load(Senders, _Senders);
            Load(Messages, _Messages);
        }
    }
}
