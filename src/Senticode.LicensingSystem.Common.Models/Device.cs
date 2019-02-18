using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class Device : ModelBase
    {
        public string Serial { get; set; }
        public KeyUser KeyUser { get; set; } //f, m:1
    }
}
