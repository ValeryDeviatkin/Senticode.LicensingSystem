using Senticode.LicensingSystem.Common.Interfaces.Models;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class OrganizationAndDevice : ModelBase, IIdentifier
    {
        int IIdentifier.Id { get; set; }
        public int OrganizationId { get; set; } //f, m:1
        public int DeviceId { get; set; } //f, 1:1
    }
}
