namespace Senticode.LicensingSystem.Common.Models
{
    public class Contract
    {
        public string Name { get; set; }
        public int KeyLimit { get; set; }
        public Organization Organization { get; set; } //f, 1:1
    }
}
