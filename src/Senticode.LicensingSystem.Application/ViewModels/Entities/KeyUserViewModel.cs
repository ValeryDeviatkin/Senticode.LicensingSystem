using Senticode.LicensingSystem.Application.ViewModels.Abstraction;
using Senticode.LicensingSystem.Common.Models;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels.Entities
{
    internal class KeyUserViewModel : EntityViewModelBase<KeyUser>
    {
        #region KeyUserName property

        /// <summary>
        /// Gets or sets the KeyUserName value.
        /// </summary>
        public string KeyUserName
        {
            get { return _keyUserName; }
            set { SetProperty(ref _keyUserName, value); }
        }

        /// <summary>
        /// KeyUserName property data.
        /// </summary>
        private string _keyUserName;

        #endregion

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

        #region OrganizationName property

        /// <summary>
        /// Gets or sets the OrganizationName value.
        /// </summary>
        public string OrganizationName
        {
            get { return _organizationName; }
            set { SetProperty(ref _organizationName, value); }
        }

        /// <summary>
        /// OrganizationName property data.
        /// </summary>
        private string _organizationName;

        #endregion

        public KeyUserViewModel(IUnityContainer container, KeyUser entity) : base(container, entity)
        {
        }

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(KeyUserName):
                    {
                        if (string.IsNullOrWhiteSpace(KeyUserName)) return "NULL";
                        break;
                    }
                }

                return null;
            }
        }
    }
}
