using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContentsManagementStudio.Commons
{
    class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> _act { get; }

        public Command(Action<object> act)
        {
            _act = act;
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _act.Invoke(parameter);
    }
}
