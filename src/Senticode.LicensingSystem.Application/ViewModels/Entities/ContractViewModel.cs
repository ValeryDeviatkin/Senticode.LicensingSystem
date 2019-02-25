using Senticode.LicensingSystem.Application.ViewModels.Abstraction;
using Senticode.LicensingSystem.Common.Models;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels.Entities
{
    internal class ContractViewModel : EntityViewModelBase<Contract>
    {
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

        public ContractViewModel(IUnityContainer container, Contract entity) : base(container, entity)
        {
        }

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(KeyLimit):
                    {
                        if (KeyLimit < 0 || KeyLimit > 1000) return "[0; 1000]";
                        break;
                    }
                    case nameof(ContractName):
                    {
                        if (string.IsNullOrWhiteSpace(ContractName)) return "NULL";
                        break;
                    }
                }

                return null;
            }
        }
    }
}
