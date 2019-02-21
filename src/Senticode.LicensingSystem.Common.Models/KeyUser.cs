using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Senticode.LicensingSystem.Common.Interfaces.Models;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class KeyUser : ModelBase, IKeyUserIdentifier
    {
        [Key]
        public int KeyUserId { get; set; }
        //Key

        #region Name property

        /// <summary>
        /// Gets or sets the Name value.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        /// <summary>
        /// Name property data.
        /// </summary>
        private string _name;

        #endregion

        #region PositionName property

        /// <summary>
        /// Gets or sets the PositionName value.
        /// </summary>
        [ForeignKey(nameof(Position))]
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
        //f

        #region OrganizationName property

        /// <summary>
        /// Gets or sets the OrganizationName value.
        /// </summary>
        [ForeignKey(nameof(Organization))]
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
        //f


        #region Position property

        /// <summary>
        /// Gets or sets the Position value.
        /// </summary>
        public Position Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }

        /// <summary>
        /// Position property data.
        /// </summary>
        private Position _position;

        #endregion

        #region Organization property

        /// <summary>
        /// Gets or sets the Organization value.
        /// </summary>
        public Organization Organization
        {
            get { return _organization; }
            set { SetProperty(ref _organization, value); }
        }

        /// <summary>
        /// Organization property data.
        /// </summary>
        private Organization _organization;

        #endregion

        #region Devices property

        /// <summary>
        /// Gets or sets the Devices value.
        /// </summary>
        public ICollection<Device> Devices
        {
            get { return _devices; }
            set { SetProperty(ref _devices, value); }
        }

        /// <summary>
        /// Devices property data.
        /// </summary>
        private ICollection<Device> _devices;

        #endregion

        public KeyUser()
        {
            Devices = new List<Device>();
        }
    }
}
