using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dining_Philosophers.ViewModels
{
	class RelayCommand : ICommand
	{
		private readonly Predicate<object> _canExecute;
		private readonly Action<object> _action;

		public RelayCommand(Action<object> action, Predicate<object> canExecute)
		{
			_canExecute = canExecute;
			_action = action;
		}

		public RelayCommand(Action<object> action)
			: this(action, null)
		{
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			if (!CanExecute(parameter))
				return;

			_action(parameter);
		}

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
