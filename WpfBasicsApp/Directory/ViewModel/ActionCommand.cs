using System;
using System.Windows.Input;

namespace WpfBasicsApp
{
    /// <summary>
    /// This class handles a command that runs an action, such as a button press, tree exapnsion, etc.
    /// </summary>
    public class ActionCommand : ICommand
    {
        #region Private Attributes

        /// <summary>
        /// Action to run.
        /// </summary>
        private Action mAction;

        #endregion Private Attributes

        #region Public Events

        /// <summary>
        /// The event that executes when the <see cref="CanExecute(object)"/> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion Public Events

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ActionCommand(Action action)
        {
            mAction = action;
        }

        #endregion Constructor

        #region Command Methods

        /// <summary>
        /// Action command will always execute.
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

        #endregion Command Methods
    }
}