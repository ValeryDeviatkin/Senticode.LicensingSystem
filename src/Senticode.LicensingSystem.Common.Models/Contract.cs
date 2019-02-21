using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class Contract : ModelBase
    {
        #region OrganizationName property

        /// <summary>
        /// Gets or sets the OrganizationName value.
        /// </summary>
        [Key]
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
        //Key
        //f

        #region ContractName property

        /// <summary>
        /// Gets or sets the ContractName value.
        /// </summary>

        public string ContractName
        {
            get { return _contractName; }
            set { SetProperty(ref _contractName, value); }
        }

        /// <summary>
        /// ContractName property data.
        /// </summary>
        private string _contractName;

        #endregion

        #region KeyLimit property

        /// <summary>
        /// Gets or sets the KeyLimit value.
        /// </summary>
        public int KeyLimit
        {
            get { return _keyLimit; }
            set { SetProperty(ref _keyLimit, value); }
        }

        /// <summary>
        /// KeyLimit property data.
        /// </summary>
        private int _keyLimit;

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
    }
}
