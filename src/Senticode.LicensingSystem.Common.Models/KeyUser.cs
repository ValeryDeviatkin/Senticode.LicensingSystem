using Senticode.LicensingSystem.Common.Interfaces.Models;

namespace Senticode.LicensingSystem.Common.Models
{
    public class KeyUser : IIdentifier
    {
        int IIdentifier.Id { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; } //f, m:1
        public Organization Organization { get; set; } //f, m:1
    }
}
