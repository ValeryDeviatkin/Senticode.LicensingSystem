using System;
using System.Reflection;
using System.Windows;
using Senticode.LicensingSystem.Application.Extensions;
using Senticode.LicensingSystem.Application.ViewModels;
using Senticode.LicensingSystem.Common.Interfaces;
using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands
    {
        private readonly MethodInfo _deleteMethod = typeof(AppCommands)
            .GetMethod(nameof(ExecuteDeleteGeneric), BindingFlags.NonPublic | BindingFlags.Instance);

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
            var confirm = MessageBox.Show(
                ResourceKeys.Delete.L() + "?",
                ResourceKeys.Confirm.L(),
                MessageBoxButton.YesNo);

            if (confirm != MessageBoxResult.Yes) return;

            var args = parameter as object[];

            if (args == null)
            {
                var type = parameter as Type;
                if (type == null) return;
                var executeDelete = _deleteMethod.MakeGenericMethod(type);
                executeDelete.Invoke(this, new object[] { null });
            }
            else if (args.Length == 2)
            {
                var type = args[0] as Type;
                if (type == null) return;
                var executeDelete = _deleteMethod.MakeGenericMethod(type);
                executeDelete.Invoke(this, new[] { args[1] });
            }
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

        private void ExecuteDeleteGeneric<TEntity>(object param)
            where TEntity : ModelBase, new()
        {
            var crud = _container.Resolve<ICrud<TEntity>>();

            if (param == null)
            {
                crud.Delete(
                    ((EntityListViewModel<TEntity>)_mainViewModel.Value.EntityListViewModel)
                    .SelectedItems);
            }
            else
            {
                var entity = param as TEntity;
                if (entity == null) return;
                crud.Delete(entity);
            }
        }
    }
}
