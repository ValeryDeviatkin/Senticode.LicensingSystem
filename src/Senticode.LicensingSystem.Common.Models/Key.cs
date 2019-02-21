using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class Key : ModelBase
    {
        #region Value property

        /// <summary>
        /// Gets or sets the Value value.
        /// </summary>
        [Key]
        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        /// <summary>
        /// Value property data.
        /// </summary>
        private string _value;

        #endregion
        //Key

        #region ProductName property

        /// <summary>
        /// Gets or sets the ProductName value.
        /// </summary>
        [ForeignKey(nameof(Product))]
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }

        /// <summary>
        /// ProductName property data.
        /// </summary>
        private string _productName;

        #endregion
        //f

        #region DeviceSerial property

        /// <summary>
        /// Gets or sets the DeviceSerial value.
        /// </summary>
        [ForeignKey(nameof(Device))]
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
        //f

        #region IssueDate property

        /// <summary>
        /// Gets or sets the IssueDate value.
        /// </summary>
        public DateTime IssueDate
        {
            get { return _issueDate; }
            set { SetProperty(ref _issueDate, value); }
        }

        /// <summary>
        /// IssueDate property data.
        /// </summary>
        private DateTime _issueDate;

        #endregion

        #region StartDate property

        /// <summary>
        /// Gets or sets the StartDate value.
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }

        /// <summary>
        /// StartDate property data.
        /// </summary>
        private DateTime _startDate;

        #endregion

        #region EndDate property

        /// <summary>
        /// Gets or sets the EndDate value.
        /// </summary>
        public DateTime EndDate
        {
            get { return _endDate; }
            set { SetProperty(ref _endDate, value); }
        }

        /// <summary>
        /// EndDate property data.
        /// </summary>
        private DateTime _endDate;

        #endregion

        #region IsTestKey property

        /// <summary>
        /// Gets or sets the IsTestKey value.
        /// </summary>
        public bool IsTestKey
        {
            get { return _isTestKey; }
            set { SetProperty(ref _isTestKey, value); }
        }

        /// <summary>
        /// IsTestKey property data.
        /// </summary>
        private bool _isTestKey;

        #endregion

        #region ExtensionReason property

        /// <summary>
        /// Gets or sets the ExtensionReason value.
        /// </summary>
        public string ExtensionReason
        {
            get { return _extensionReason; }
            set { SetProperty(ref _extensionReason, value); }
        }

        /// <summary>
        /// ExtensionReason property data.
        /// </summary>
        private string _extensionReason;

        #endregion


        #region Product property

        /// <summary>
        /// Gets or sets the Product value.
        /// </summary>
        public Product Product
        {
            get { return _product; }
            set { SetProperty(ref _product, value); }
        }

        /// <summary>
        /// Product property data.
        /// </summary>
        private Product _product;

        #endregion

        #region Device property

        /// <summary>
        /// Gets or sets the Device value.
        /// </summary>
        public Device Device
        {
            get { return _device; }
            set { SetProperty(ref _device, value); }
        }

        /// <summary>
        /// Device property data.
        /// </summary>
        private Device _device;

        #endregion
    }
}
