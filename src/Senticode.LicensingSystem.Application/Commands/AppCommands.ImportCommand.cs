using System;
using System.Reflection;
using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands
    {
        private readonly MethodInfo _importMethod = typeof(AppCommands)
            .GetMethod(nameof(ExecuteImportGeneric), BindingFlags.NonPublic | BindingFlags.Instance);

        #region Import command

        /// <summary>
        /// Gets the Import command.
        /// </summary>
        public Command ImportCommand => _importCommand ??
                                   (_importCommand = new Command(ExecuteImport, CanExecuteImport));

        private Command _importCommand;

        /// <summary>
        /// Method to invoke when the Import command is executed.
        /// </summary>
        private void ExecuteImport(object parameter)
        {
            var type = parameter as Type;
            if (type == null) return;

            var executeImport = _importMethod.MakeGenericMethod(type);
            executeImport.Invoke(this, null);
        }

        /// <summary>
        /// Method to check whether the Import command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool CanExecuteImport()
        {
            return true;
        }

        #endregion

        private void ExecuteImportGeneric<TEntity>()
            where TEntity : ModelBase
        {
            
        }
    }
}
