using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Metro.Commands
{
    public class RelayCommand : ICommand
    {
        //public event EventHandler CanExecuteChanged;

        readonly Action<object> executeMethod;
        readonly Func<object, bool> canExecuteMethod;
                
        public RelayCommand(Action<object> oexecuteMethod, Func<object, bool> ocanExecuteMethod)
        {
            executeMethod = oexecuteMethod;
            canExecuteMethod = ocanExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
