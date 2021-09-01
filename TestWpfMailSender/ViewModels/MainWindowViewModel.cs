using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.ViewModels.Base;

namespace TestWpfMailSender.ViewModels
{
   internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Рассыльщик";
        public string Title { get => _Title; set => Set(ref _Title, value); }


        private string _Status = "Готов!";
        public string Status { get => _Status; set => Set(ref _Status, value); }
    }
}
