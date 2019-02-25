using Senticode.WPF.Tools.Core;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands
    {
        #region Edit command

        /// <summary>
        /// Gets the Edit command.
        /// </summary>
        public Command EditCommand => _editCommand ??
                                   (_editCommand = new Command(ExecuteEdit, CanExecuteEdit));

        private Command _editCommand;

        /// <summary>
        /// Method to invoke when the Edit command is executed.
        /// </summary>
        private void ExecuteEdit(object parameter)
        {
            // TODO: Handle command logic here
        }

        /// <summary>
        /// Method to check whether the Edit command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool CanExecuteEdit()
        {
            return true;
        }

        #endregion
    }
}
