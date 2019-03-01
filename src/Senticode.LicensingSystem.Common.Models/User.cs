using System.ComponentModel.DataAnnotations;
using Senticode.LicensingSystem.Common.Interfaces.Enums;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class User : ModelBase
    {
        [Key]
        public int Id { get; set; }
        //Key

        #region Password property

        /// <summary>
        /// Gets or sets the Password value.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        /// <summary>
        /// Password property data.
        /// </summary>
        private string _password;

        #endregion

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
        public Boolean IsReadingAvailable
        {
            get { return _isReadingAvailable; }
            set { SetProperty(ref _isReadingAvailable, value); }
        }

        /// <summary>
        /// IsReadingAvailable property data.
        /// </summary>
        private Boolean _isReadingAvailable;

        #endregion

        #region IsWritingAvailable property

        /// <summary>
        /// Gets or sets the IsWritingAvailable value.
        /// </summary>
        public Boolean IsWritingAvailable
        {
            get { return _isWritingAvailable; }
            set { SetProperty(ref _isWritingAvailable, value); }
        }

        /// <summary>
        /// IsWritingAvailable property data.
        /// </summary>
        private Boolean _isWritingAvailable;

        #endregion

        #region IsReadingKeysAvailable property

        /// <summary>
        /// Gets or sets the IsReadingKeysAvailable value.
        /// </summary>
        public Boolean IsReadingKeysAvailable
        {
            get { return _isReadingKeysAvailable; }
            set { SetProperty(ref _isReadingKeysAvailable, value); }
        }

        /// <summary>
        /// IsReadingKeysAvailable property data.
        /// </summary>
        private Boolean _isReadingKeysAvailable;

        #endregion

        #region HasAccessToWorkingKeys property

        /// <summary>
        /// Gets or sets the HasAccessToWorkingKeys value.
        /// </summary>
        public Boolean HasAccessToWorkingKeys
        {
            get { return _hasAccessToWorkingKeys; }
            set { SetProperty(ref _hasAccessToWorkingKeys, value); }
        }

        /// <summary>
        /// HasAccessToWorkingKeys property data.
        /// </summary>
        private Boolean _hasAccessToWorkingKeys;

        #endregion

        #region HasAccessToTestKeys property

        /// <summary>
        /// Gets or sets the HasAccessToTestKeys value.
        /// </summary>
        public Boolean HasAccessToTestKeys
        {
            get { return _hasAccessToTestKeys; }
            set { SetProperty(ref _hasAccessToTestKeys, value); }
        }

        /// <summary>
        /// HasAccessToTestKeys property data.
        /// </summary>
        private Boolean _hasAccessToTestKeys;

        #endregion

        #region IsAdmin property

        /// <summary>
        /// Gets or sets the IsAdmin value.
        /// </summary>
        public Boolean IsAdmin
        {
            get { return _isAdmin; }
            set { SetProperty(ref _isAdmin, value); }
        }

        /// <summary>
        /// IsAdmin property data.
        /// </summary>
        private Boolean _isAdmin;

        #endregion
    }
}
