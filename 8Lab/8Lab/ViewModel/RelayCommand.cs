// ViewModels/RelayCommand.cs
using System.Windows.Input;

namespace _8Lab.ViewModel
{
    // Класс для реализации команды (паттерн Command)
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute; // Действие, которое выполняет команда
        private readonly Func<object, bool> _canExecute; // Функция, определяющая, может ли команда выполняться

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null!)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Определяет, может ли команда выполняться
        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter!) ?? true;

        // Выполняет команду
        public void Execute(object? parameter) => _execute(parameter!);
    }
}
