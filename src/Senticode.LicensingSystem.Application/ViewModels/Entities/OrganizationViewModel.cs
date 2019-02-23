using Senticode.LicensingSystem.Common.Models;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels.Entities
{
    internal class OrganizationViewModel : EntityViewModelBase<Organization>
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

        public OrganizationViewModel(IUnityContainer container, Organization entity) : base(container, entity)
        {
        }
    }
}
