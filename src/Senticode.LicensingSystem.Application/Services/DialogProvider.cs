using System.Windows;
using Senticode.LicensingSystem.Application.ViewModels.Entities;
using Senticode.LicensingSystem.Application.Views.EditWindows;
using Senticode.LicensingSystem.Common.Interfaces.Enums;
using Senticode.WPF.Tools.MVVM;
using Unity;
using Unity.Resolution;

namespace Senticode.LicensingSystem.Application.Services
{
    internal class DialogProvider
    {
        private readonly IUnityContainer _container;

        public DialogProvider(IUnityContainer container)
        {
            container.RegisterInstance(this);
            _container = container;
        }

        public Window CreateDialog<TEntity>(
            string title,
            out EntityViewModelBase<TEntity> viewModel,
            TEntity entity = default(TEntity)
        )
            where TEntity : ModelBase, new()
        {
            var window = _container.Resolve<EditEntityWindowBase<TEntity>>();
            window.Title = title;

            viewModel = _container.Resolve<EntityViewModelBase<TEntity>>(
                new ParameterOverride(Param.container.ToString(), _container),
                new ParameterOverride(Param.entity.ToString(), entity ?? new TEntity()));

            window.DataContext = viewModel;
            return window;
        }
    }
}