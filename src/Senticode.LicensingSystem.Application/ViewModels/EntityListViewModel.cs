using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Data;
using Senticode.LicensingSystem.Application.Services;
using Senticode.LicensingSystem.Application.ViewModels.Abstraction;
using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels //todo unsubscribe events
{
    internal class EntityListViewModel<TEntity> : ViewModelBase<AppCommandsBase>, IPropertyNames, ITypeViewModel
        where TEntity : ModelBase, new()
    {
        private readonly ViewModelsProvider _provider;

        public EntityListViewModel(
            IUnityContainer container,
            ViewModelsProvider provider)
            : base(container)
        {
            container.RegisterInstance(this);
            _provider = provider;
            PropertyNames = provider.GetEntityViewModel<TEntity>().PropertyNames;
            Filter = PropertyNames.FirstOrDefault();
            EntityViewModels = new ObservableRangeCollection<EntityViewModelBase<TEntity>>();
            var crud = container.Resolve<ICrud<TEntity>>();

            if (crud.LocalEntities != null)
            {
                crud.LocalEntities.CollectionChanged += LocalEntitiesOnCollectionChanged;

                foreach (var entity in crud.LocalEntities)
                {
                    var viewModel = _provider.GetEntityViewModel(entity);
                    EntityViewModels.Add(viewModel);
                }
            }

            CollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(EntityViewModels);
            CollectionView.Filter = EntityFilter;
            
        }

        public void Initialize()
        {
            CollectionView.CustomSort = Container.Resolve<EntityComparer<TEntity>>();
        }

        private void LocalEntitiesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                {
                    foreach (var newItem in e.NewItems)
                    {
                        var viewModel = _provider.GetEntityViewModel((TEntity)newItem);
                        EntityViewModels.Add(viewModel);
                    }
                }
                    break;

                case NotifyCollectionChangedAction.Remove:
                {
                    var viewModelsToDelete = new List<EntityViewModelBase<TEntity>>();

                    foreach (var oldItem in e.OldItems)
                    {
                        viewModelsToDelete.Add(EntityViewModels.First(x => x.Entity.Equals(oldItem)));
                    }

                    foreach (var entityViewModel in viewModelsToDelete)
                    {
                        EntityViewModels.Remove(entityViewModel);
                    }

                }
                    break;
            }
        }

        private bool EntityFilter(object obj)
        {
            var entityViewModel = (EntityViewModelBase<TEntity>)obj;
            if (string.IsNullOrWhiteSpace(SearchString)) return true;

            var searchString = SearchString.Trim().ToLower();
            var itemValue = entityViewModel
                .GetFromModel<TEntity, object>(Filter) //todo concrete type
                .ToString()
                .Trim();

            return itemValue
                .ToLower()
                .Contains(searchString);
        }

        public ListCollectionView CollectionView { get; }

        public TEntity[] SelectedItems
        {
            get { return EntityViewModels.Where(x => x.IsSelected).Select(x => x.Entity).ToArray(); }
        }

        #region IsDescending property

        /// <summary>
        ///     Gets or sets the IsDescending value.
        /// </summary>
        public bool IsDescending
        {
            get { return _isDescending; }
            set
            {
                SetProperty(ref _isDescending, value);
                CollectionView.Refresh();
            }
        }

        /// <summary>
        ///     IsDescending property data.
        /// </summary>
        private bool _isDescending;

        #endregion

        #region Filter property

        /// <summary>
        ///     Gets or sets the Filter value.
        /// </summary>
        public string Filter
        {
            get { return _filter; }
            set
            {
                SetProperty(ref _filter, value);
                CollectionView?.Refresh();
            }
        }

        /// <summary>
        ///     Filter property data.
        /// </summary>
        private string _filter;

        #endregion

        #region SearchString property

        /// <summary>
        ///     Gets or sets the SearchString value.
        /// </summary>
        public string SearchString
        {
            get { return _searchString; }
            set
            {
                SetProperty(ref _searchString, value);
                CollectionView?.Refresh();
            }
        }

        /// <summary>
        ///     SearchString property data.
        /// </summary>
        private string _searchString;

        #endregion

        #region EntityViewModels property

        /// <summary>
        ///     Gets or sets the EntityViewModels value.
        /// </summary>
        public ObservableRangeCollection<EntityViewModelBase<TEntity>> EntityViewModels
        {
            get { return _entityViewModels; }
            set { SetProperty(ref _entityViewModels, value); }
        }

        /// <summary>
        ///     EntityViewModels property data.
        /// </summary>
        private ObservableRangeCollection<EntityViewModelBase<TEntity>> _entityViewModels;

        #endregion

        public string[] PropertyNames { get; }
        public Type Type { get; } = typeof(TEntity);
    }
}