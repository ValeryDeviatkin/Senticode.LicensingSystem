using Senticode.WPF.Tools.Core;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands
    {
        #region Delete command

        /// <summary>
        /// Gets the Delete command.
        /// </summary>
        public Command DeleteCommand => _deleteCommand ??
                                   (_deleteCommand = new Command(ExecuteDelete, CanExecuteDelete));

        private Command _deleteCommand;

        /// <summary>
        /// Method to invoke when the Delete command is executed.
        /// </summary>
        private void ExecuteDelete(object parameter)
        {
            // TODO: Handle command logic here
        }

        /// <summary>
        /// Method to check whether the Delete command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool CanExecuteDelete()
        {
            return true;
        }

        #endregion
    }
}
