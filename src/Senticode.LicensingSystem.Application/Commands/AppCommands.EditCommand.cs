using System;
using System.Reflection;
using Senticode.LicensingSystem.Application.Extensions;
using Senticode.LicensingSystem.Application.ViewModels.Abstraction;
using Senticode.LicensingSystem.Common.Interfaces;
using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands
    {
        private readonly MethodInfo _updateMethod = typeof(AppCommands)
            .GetMethod(nameof(ExecuteUpdateGeneric), BindingFlags.NonPublic | BindingFlags.Instance);

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
            var args = parameter as object[];

            if (args?.Length == 2)
            {
                var type = args[0] as Type;
                if (type == null) return;
                var executeUpdate = _updateMethod.MakeGenericMethod(type);
                executeUpdate.Invoke(this, new[] { args[1] });
            }
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

        private void ExecuteUpdateGeneric<TEntity>(object param)
            where TEntity : ModelBase, new()
        {
            var entity = param as TEntity;
            if (entity == null) return;
            var crud = _container.Resolve<ICrud<TEntity>>();
            var oldKeyValues = crud.GetKeyValues(entity);
            EntityViewModelBase<TEntity> viewModel;

            var dialog = _dialogProvider.CreateDialog(
                ResourceKeys.Edit.L() + " " + typeof(TEntity).Name.L(),
                out viewModel,
                entity);

            if (dialog.ShowDialog() ?? false)
            {
                viewModel.UpdateModel();
                crud.Update(entity, oldKeyValues);
            }
        }
    }
}
