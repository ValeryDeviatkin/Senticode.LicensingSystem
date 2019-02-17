using Senticode.LicensingSystem.Common.Interfaces.Models;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class OrganizationAndContarct : ModelBase, IIdentifier
    {
        int IIdentifier.Id { get; set; }
        public int OrganizationId { get; set; } //f, 1:1
        public int ContractId { get; set; } //f, 1:1
    }
}
