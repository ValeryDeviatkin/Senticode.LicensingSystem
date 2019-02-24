using Senticode.LicensingSystem.Common.Models;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels.Entities
{
    internal class DeviceViewModel : EntityViewModelBase<Device>
    {
        #region DeviceSerial property

        /// <summary>
        /// Gets or sets the DeviceSerial value.
        /// </summary>
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

        public DeviceViewModel(IUnityContainer container, Device entity) : base(container, entity)
        {
        }

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(DeviceSerial):
                    {
                        if (string.IsNullOrWhiteSpace(DeviceSerial)) return "NULL";
                        break;
                    }
                }

                return null;
            }
        }
    }
}
