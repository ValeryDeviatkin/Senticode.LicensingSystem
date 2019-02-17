using Senticode.LicensingSystem.Common.Interfaces.Models;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class ProductAndKey : ModelBase, IIdentifier
    {
        int IIdentifier.Id { get; set; }
        public int ProductId { get; set; } //f, m:1
        public int KeyId { get; set; } //f, 1:1
    }
}
