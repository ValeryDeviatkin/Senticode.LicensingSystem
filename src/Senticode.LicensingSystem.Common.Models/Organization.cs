using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class Organization : ModelBase
    {
        #region OrganizationName property

        /// <summary>
        /// Gets or sets the OrganizationName value.
        /// </summary>
        [Key]
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
        //Key


        #region Contract property

        /// <summary>
        /// Gets or sets the Contract value.
        /// </summary>
        public Contract Contract
        {
            get { return _contract; }
            set { SetProperty(ref _contract, value); }
        }

        /// <summary>
        /// Contract property data.
        /// </summary>
        private Contract _contract;

        #endregion

        #region KeyUsers property

        /// <summary>
        /// Gets or sets the KeyUsers value.
        /// </summary>
        public ICollection<KeyUser> KeyUsers
        {
            get { return _keyUsers; }
            set { SetProperty(ref _keyUsers, value); }
        }

        /// <summary>
        /// KeyUsers property data.
        /// </summary>
        private ICollection<KeyUser> _keyUsers;

        #endregion

        public Organization()
        {
            KeyUsers = new List<KeyUser>();
        }
    }
}
