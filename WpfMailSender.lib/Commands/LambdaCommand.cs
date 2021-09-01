using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Commands.Base;

namespace WpfMailSender.lib.Commands
{
    public class LambdaCommand : Command
    {
        public Action<object> _Execute { get; }
        public Func<object, bool> _CanExecute { get; }
        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }


        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter)
        {
            if(CanExecute(parameter))
            _Execute(parameter);
        }
    }
}
