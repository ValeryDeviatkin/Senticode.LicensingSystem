using Senticode.WPF.Tools.MVVM;
using System;

namespace Senticode.LicensingSystem.Common.Models
{
    public class Key : ModelBase
    {
        public string Value { get; set; }
        public Product Product { get; set; } //f, m:1
        public Device Device { get; set; } //f, m:1
        public DateTime IssueDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsTestKey { get; set; }
        public string ExtensionReason { get; set; }
    }
}
