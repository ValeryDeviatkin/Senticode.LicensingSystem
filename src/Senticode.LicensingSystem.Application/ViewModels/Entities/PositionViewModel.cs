using Senticode.LicensingSystem.Common.Models;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels.Entities
{
    internal class PositionViewModel : EntityViewModelBase<Position>
    {
        #region PositionName property

        /// <summary>
        /// Gets or sets the PositionName value.
        /// </summary>
        public string PositionName
        {
            get { return _positionName; }
            set { SetProperty(ref _positionName, value); }
        }

        /// <summary>
        /// PositionName property data.
        /// </summary>
        private string _positionName;

        #endregion
        
        public PositionViewModel(IUnityContainer container, Position entity) : base(container, entity)
        {
        }

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(PositionName):
                    {
                        if (string.IsNullOrWhiteSpace(PositionName)) return "NULL";
                        break;
                    }
                }

                return null;
            }
        }
    }
}
