namespace Senticode.LicensingSystem.Common.Models
{
    public class Device
    {
        public string Serial { get; set; }
        public KeyUser KeyUser { get; set; } //f, m:1
    }
}
