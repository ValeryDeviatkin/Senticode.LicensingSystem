using Senticode.LicensingSystem.Common.Models;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels.Entities
{
    internal class UserViewModel : EntityViewModelBase<User>
    {
        #region Login property

        /// <summary>
        /// Gets or sets the Login value.
        /// </summary>
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        /// <summary>
        /// Login property data.
        /// </summary>
        private string _login;

        #endregion

        #region IsReadingAvailable property

        /// <summary>
        /// Gets or sets the IsReadingAvailable value.
        /// </summary>
        public bool IsReadingAvailable
        {
            get { return _isReadingAvailable; }
            set { SetProperty(ref _isReadingAvailable, value); }
        }

        /// <summary>
        /// IsReadingAvailable property data.
        /// </summary>
        private bool _isReadingAvailable;

        #endregion

        #region IsWritingAvailable property

        /// <summary>
        /// Gets or sets the IsWritingAvailable value.
        /// </summary>
        public bool IsWritingAvailable
        {
            get { return _isWritingAvailable; }
            set { SetProperty(ref _isWritingAvailable, value); }
        }

        /// <summary>
        /// IsWritingAvailable property data.
        /// </summary>
        private bool _isWritingAvailable;

        #endregion

        #region IsReadingKeysAvailable property

        /// <summary>
        /// Gets or sets the IsReadingKeysAvailable value.
        /// </summary>
        public bool IsReadingKeysAvailable
        {
            get { return _isReadingKeysAvailable; }
            set { SetProperty(ref _isReadingKeysAvailable, value); }
        }

        /// <summary>
        /// IsReadingKeysAvailable property data.
        /// </summary>
        private bool _isReadingKeysAvailable;

        #endregion

        #region HasAccessToWorkingKeys property

        /// <summary>
        /// Gets or sets the HasAccessToWorkingKeys value.
        /// </summary>
        public bool HasAccessToWorkingKeys
        {
            get { return _hasAccessToWorkingKeys; }
            set { SetProperty(ref _hasAccessToWorkingKeys, value); }
        }

        /// <summary>
        /// HasAccessToWorkingKeys property data.
        /// </summary>
        private bool _hasAccessToWorkingKeys;

        #endregion

        #region HasAccessToTestKeys property

        /// <summary>
        /// Gets or sets the HasAccessToTestKeys value.
        /// </summary>
        public bool HasAccessToTestKeys
        {
            get { return _hasAccessToTestKeys; }
            set { SetProperty(ref _hasAccessToTestKeys, value); }
        }

        /// <summary>
        /// HasAccessToTestKeys property data.
        /// </summary>
        private bool _hasAccessToTestKeys;

        #endregion

        #region IsAdmin property

        /// <summary>
        /// Gets or sets the IsAdmin value.
        /// </summary>
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { SetProperty(ref _isAdmin, value); }
        }

        /// <summary>
        /// IsAdmin property data.
        /// </summary>
        private bool _isAdmin;

        #endregion

        public UserViewModel(IUnityContainer container, User entity) : base(container, entity)
        {
        }

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Login):
                    {
                        if (string.IsNullOrWhiteSpace(Login)) return "NULL";
                        break;
                    }
                }

                return null;
            }
        }
    }
}
