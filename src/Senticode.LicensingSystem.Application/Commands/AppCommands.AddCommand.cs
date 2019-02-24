using System;
using System.Reflection;
using Senticode.LicensingSystem.Application.Extensions;
using Senticode.LicensingSystem.Application.ViewModels.Entities;
using Senticode.LicensingSystem.Common.Interfaces;
using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands
    {
        private readonly MethodInfo _addMethod = typeof(AppCommands)
            .GetMethod(nameof(ExecuteAddGeneric), BindingFlags.NonPublic | BindingFlags.Instance);

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
            var type = parameter as Type;
            if (type == null) return;

            var executeAdd = _addMethod.MakeGenericMethod(type);
            executeAdd.Invoke(this, null);
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
        
        private void ExecuteAddGeneric<TEntity>()
            where TEntity : ModelBase, new()
        {
            EntityViewModelBase<TEntity> viewModel;

            var dialog = _dialogProvider.CreateDialog(
                ResourceKeys.Add.L() + " " + typeof(TEntity).Name.L(),
                out viewModel);

            if (dialog.ShowDialog() ?? false)
            {
                viewModel.UpdateModel();
                var crud = _container.Resolve<ICrud<TEntity>>();
                crud.Add(viewModel.Entity);
            }
        }
    }
}
