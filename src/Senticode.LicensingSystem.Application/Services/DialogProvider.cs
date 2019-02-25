using System.Windows;
using Senticode.LicensingSystem.Application.ViewModels.Abstraction;
using Senticode.LicensingSystem.Application.Views.EditWindows.Abstraction;
using Senticode.LicensingSystem.Common.Interfaces.Enums;
using Senticode.WPF.Tools.MVVM;
using Unity;
using Unity.Resolution;

namespace Senticode.LicensingSystem.Application.Services
{
    internal class DialogProvider
    {
        private readonly IUnityContainer _container;
        private readonly ViewModelsProvider _viewModelsProvider;

        public DialogProvider(
            IUnityContainer container,
            ViewModelsProvider viewModelsProvider)
        {
            container.RegisterInstance(this);
            _container = container;
            _viewModelsProvider = viewModelsProvider;
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
            viewModel = _viewModelsProvider.GetEntityViewModel(entity);
            window.DataContext = viewModel;
            return window;
        }
    }
}