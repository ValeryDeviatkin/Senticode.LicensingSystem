using System;
using System.Collections;
using Senticode.LicensingSystem.Application.ViewModels;
using Senticode.LicensingSystem.Application.ViewModels.Abstraction;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.Services
{
    internal class EntityComparer<TEntity> : IComparer
        where TEntity : ModelBase, new()
    {
        private readonly EntityListViewModel<TEntity> _listViewModel;

        public EntityComparer(IUnityContainer container, EntityListViewModel<TEntity> listViewModel)
        {
            _listViewModel = listViewModel;
            container.RegisterInstance(this);
        }

        public int Compare(object x, object y)
        {
            var itemX = x as EntityViewModelBase<TEntity>;
            var itemY = y as EntityViewModelBase<TEntity>;
            if (itemX == null || itemY == null) throw new InvalidCastException();
            var property = itemX.ModelProperties[_listViewModel.Filter];
            var xValue = property?.GetValue(x).ToString();
            var yValue = property?.GetValue(y).ToString();

            return _listViewModel.IsDescending ?
                string.Compare(yValue, xValue, StringComparison.Ordinal)
                : string.Compare(xValue, yValue, StringComparison.Ordinal);
        }
    }
}
