using Senticode.LicensingSystem.Common.Interfaces.Models;

namespace Senticode.LicensingSystem.Common.Models
{
    public class User : IIdentifier
    {
        int IIdentifier.Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public bool IsReadingAvailable { get; set; }
        public bool IsWritingAvailable { get; set; }
        public bool IsReadingKeysAvailable { get; set; }
        public bool HasAccessToWorkingKeys { get; set; }
        public bool HasAccessToTestKeys { get; set; }
        public bool IsAdmin { get; set; }
    }
}
