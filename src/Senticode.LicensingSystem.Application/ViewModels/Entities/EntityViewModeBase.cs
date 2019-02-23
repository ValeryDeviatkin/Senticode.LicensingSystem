using Senticode.WPF.Tools.MVVM;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels.Entities
{
    internal abstract class EntityViewModelBase<TEntity> : ViewModelBase
        where TEntity : ModelBase, new()
    {
        #region Entity property

        /// <summary>
        /// Gets or sets the Entity value.
        /// </summary>
        public TEntity Entity
        {
            get { return _entity; }
            set { SetProperty(ref _entity, value); }
        }

        /// <summary>
        /// Entity property data.
        /// </summary>
        private TEntity _entity;

        #endregion
        
        protected EntityViewModelBase(IUnityContainer container, TEntity entity) : base(container)
        {
            Entity = entity;
            SetModel(entity);
        }
    }
}
