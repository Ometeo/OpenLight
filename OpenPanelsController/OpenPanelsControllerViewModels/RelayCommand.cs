using System;
using System.Windows.Input;

namespace OpenPanelsControllerViewModels
{
    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute) : base(execute, canExecute)
        {
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute = null;
        private readonly Predicate<T> canExecute = null;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (null == execute)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<T> execute) : this(execute, null)

        {
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            execute((T)parameter);
        }
    }
}