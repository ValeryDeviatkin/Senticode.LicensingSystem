using Senticode.LicensingSystem.Common.Interfaces.Models;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class Device : ModelBase, IIdentifier
    {
        int IIdentifier.Id { get; set; }
        public string Serial { get; set; }
    }
}
