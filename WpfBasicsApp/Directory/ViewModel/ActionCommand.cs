
using System;
using System.Windows.Input;

namespace WpfBasicsApp
{
    public class ActionCommand : ICommand
    {
        /// <summary>
        /// The event that executes when the <see cref="CanExecute(object)"/> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        /// <summary>
        /// Action command will always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>true</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
