using Senticode.LicensingSystem.Common.Interfaces.Models;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class KeyUser : ModelBase, IIdentifier
    {
        int IIdentifier.Id { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; } //f, 1:m
        public int OrganizationId { get; set; } //f, 1:m
    }
}
