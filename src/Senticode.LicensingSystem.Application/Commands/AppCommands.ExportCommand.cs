using System;
using System.Reflection;
using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands
    {
        private readonly MethodInfo _exportMethod = typeof(AppCommands)
            .GetMethod(nameof(ExecuteExportGeneric), BindingFlags.NonPublic | BindingFlags.Instance);

        #region Export command

        /// <summary>
        /// Gets the Export command.
        /// </summary>
        public Command ExportCommand => _exportCommand ??
                                   (_exportCommand = new Command(ExecuteExport, CanExecuteExport));

        private Command _exportCommand;

        /// <summary>
        /// Method to invoke when the Export command is executed.
        /// </summary>
        private void ExecuteExport(object parameter)
        {
            var type = parameter as Type;
            if (type == null) return;

            var executeExport = _exportMethod.MakeGenericMethod(type);
            executeExport.Invoke(this, null);
        }

        /// <summary>
        /// Method to check whether the Export command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool CanExecuteExport()
        {
            return true;
        }

        #endregion

        private void ExecuteExportGeneric<TEntity>()
            where TEntity : ModelBase
        {
            
        }
    }
}
