using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMailSender.lib.Commands.Base;

namespace WpfMailSender.lib.Commands
{
    public class CloseAppCommand : Command
    {
        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
