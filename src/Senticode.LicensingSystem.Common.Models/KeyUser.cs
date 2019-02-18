using Senticode.LicensingSystem.Common.Interfaces.Models;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class KeyUser : ModelBase, IIdentifier
    {
        int IIdentifier.Id { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; } //f, m:1
        public Organization Organization { get; set; } //f, m:1
    }
}
