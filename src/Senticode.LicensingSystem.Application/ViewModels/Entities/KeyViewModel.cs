﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Senticode.LicensingSystem.Common.Models;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels.Entities
{
    internal class KeyViewModel : EntityViewModelBase<Key>
    {
        #region Value property

        /// <summary>
        /// Gets or sets the Value value.
        /// </summary>
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

        #region ProductName property

        /// <summary>
        /// Gets or sets the ProductName value.
        /// </summary>
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

        public KeyViewModel(IUnityContainer container, Key entity) : base(container, entity)
        {
        }
    }
}