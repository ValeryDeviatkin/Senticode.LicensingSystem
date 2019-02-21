using Senticode.WPF.Tools.Core;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands
    {
        #region Add command

        /// <summary>
        /// Gets the Add command.
        /// </summary>
        public Command AddCommand => _addCommand ??
                                   (_addCommand = new Command(ExecuteAdd, CanExecuteAdd));

        private Command _addCommand;

        /// <summary>
        /// Method to invoke when the Add command is executed.
        /// </summary>
        private void ExecuteAdd(object parameter)
        {
            //todo
        }

        /// <summary>
        /// Method to check whether the Add command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool CanExecuteAdd()
        {
            return true;
        }

        #endregion
    }
}
