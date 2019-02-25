using System;
using System.Linq;
using System.Reflection;
using Senticode.LicensingSystem.Application.ViewModels;
using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands
    {
        private readonly MethodInfo _databaseMethod = typeof(AppCommands)
            .GetMethod(nameof(ExecuteDatabaseGeneric), BindingFlags.NonPublic | BindingFlags.Instance);

        #region Database command

        /// <summary>
        /// Gets the Database command.
        /// </summary>
        public Command DatabaseCommand => _databaseCommand ??
                                   (_databaseCommand = new Command(ExecuteDatabase, CanExecuteDatabase));

        private Command _databaseCommand;

        /// <summary>
        /// Method to invoke when the Database command is executed.
        /// </summary>
        private void ExecuteDatabase(object parameter)
        {
            var type = parameter as Type;
            if (type == null) return;

            var executeDatabase = _databaseMethod.MakeGenericMethod(type);
            executeDatabase.Invoke(this, null);
        }

        /// <summary>
        /// Method to check whether the Database command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool CanExecuteDatabase()
        {
            return true;
        }

        #endregion

        private void ExecuteDatabaseGeneric<TEntity>()
            where TEntity : ModelBase, new()
        {
            var viewModel = _container.Resolve<EntityListViewModel<TEntity>>();
            _mainViewModel.Value.EntityListViewModel = viewModel;
        }
    }
}
