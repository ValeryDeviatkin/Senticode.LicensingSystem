using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels.Abstraction
{
    internal abstract class EntityViewModelBase<TEntity> : ViewModelBase<AppCommandsBase>,
        IDataErrorInfo, ITypeViewModel, IPropertyNames
        where TEntity : ModelBase, new()
    {
        public Dictionary<string, PropertyInfo> PocoModelProperties { get; }

        protected EntityViewModelBase(IUnityContainer container, TEntity entity) : base(container)
        {
            SetModel(entity);
            Entity = entity;

            var list = new List<PropertyInfo>();

            foreach (var modelProperty in ModelProperties)
            {
                var property = Type.GetProperty(modelProperty.Key);

                if (property != null)
                {
                    list.Add(property);
                    modelProperty.Value.SetValue(this, property.GetValue(Entity));
                }
            }

            PocoModelProperties = list.ToDictionary(x => x.Name, y => y);
            PropertyNames = PocoModelProperties.Keys.ToArray();
        }

        public string[] PropertyNames { get; }

        public string[] PropertyValues
        {
            get
            {
                return PocoModelProperties.Values.
                    Select(x => x.GetValue(this).ToString()).ToArray();
            }
        }


        private MainViewModel _mainViewModel;
        public MainViewModel MainViewModel =>
            _mainViewModel ?? (_mainViewModel = Container.Resolve<MainViewModel>());

        public abstract string this[string columnName] { get; }
        public string Error { get; }

        public Type Type { get; } = typeof(TEntity);

        public void UpdateModel()
        {
            foreach (var modelProperty in PocoModelProperties)
            {
                var value = ModelProperties[modelProperty.Key].GetValue(this);
                modelProperty.Value.SetValue(Entity, value);
            }
        }

        #region Entity property

        /// <summary>
        ///     Gets or sets the Entity value.
        /// </summary>
        public TEntity Entity
        {
            get { return _entity; }
            set { SetProperty(ref _entity, value); }
        }

        /// <summary>
        ///     Entity property data.
        /// </summary>
        private TEntity _entity;
        
        #endregion

        #region IsSelected property

        /// <summary>
        /// Gets or sets the IsSelected value.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

        /// <summary>
        /// IsSelected property data.
        /// </summary>
        private bool _isSelected;

        #endregion

        #region Visibility property

        /// <summary>
        /// Gets or sets the Visibility value.
        /// </summary>
        public Visibility Visibility
        {
            get { return _visibility; }
            set { SetProperty(ref _visibility, value); }
        }

        /// <summary>
        /// Visibility property data.
        /// </summary>
        private Visibility _visibility;

        #endregion
    }
}