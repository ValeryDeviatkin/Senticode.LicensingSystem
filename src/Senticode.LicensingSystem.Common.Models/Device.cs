using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class Device : ModelBase
    {
        #region DeviceSerial property

        /// <summary>
        /// Gets or sets the DeviceSerial value.
        /// </summary>
        [Key]
        public string DeviceSerial
        {
            get { return _deviceSerial; }
            set { SetProperty(ref _deviceSerial, value); }
        }

        /// <summary>
        /// DeviceSerial property data.
        /// </summary>
        private string _deviceSerial;

        #endregion
        //Key

        #region KeyUserName property

        /// <summary>
        /// Gets or sets the KeyUserName value.
        /// </summary>
        [ForeignKey(nameof(KeyUser))]
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
        //f
        

        #region KeyUser property

        /// <summary>
        /// Gets or sets the KeyUser value.
        /// </summary>
        public KeyUser KeyUser
        {
            get { return _keyUser; }
            set { SetProperty(ref _keyUser, value); }
        }

        /// <summary>
        /// KeyUser property data.
        /// </summary>
        private KeyUser _keyUser;

        #endregion

        #region Keys property

        /// <summary>
        /// Gets or sets the Keys value.
        /// </summary>
        public ICollection<Key> Keys
        {
            get { return _keys; }
            set { SetProperty(ref _keys, value); }
        }

        /// <summary>
        /// Keys property data.
        /// </summary>
        private ICollection<Key> _keys;

        #endregion

        public Device()
        {
            Keys = new List<Key>();
        }
    }
}
