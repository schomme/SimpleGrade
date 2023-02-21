using System;
using System.Windows.Input;

namespace SimpleGradeClient.Base
{
    public class RelayCommand : ICommand
    {
        public Action<object?> ExecuteCommand { get; private set; }
        public Func<object?, bool> CanExecuteCommand { get; private set; }

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object?> executeCommand)
        {
            ExecuteCommand = executeCommand;
            CanExecuteCommand = o => true;
        }

        public RelayCommand(Action<object?> executeCommand, Func<object?, bool> canExecuteCommand)
        {
            ExecuteCommand = executeCommand;
            CanExecuteCommand = canExecuteCommand;
        }

        public bool CanExecute(object? parameter)
        {
            return this.CanExecuteCommand?.Invoke(parameter) ?? false;
        }

        public void Execute(object? parameter)
        {
            this.ExecuteCommand?.Invoke(parameter);
        }
    }
}
