using System;
using Senticode.LicensingSystem.Common.Interfaces.Models;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class Key : ModelBase, IIdentifier
    {
        int IIdentifier.Id { get; set; }
        public string Value { get; set; }
        public int OrganizationId { get; set; } //f, m:1
        public int ProductId { get; set; } //f, m:1
        public int DeviceId { get; set; } //f, m:1
        public DateTime IssueDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsTestKey { get; set; }
        public string ExtensionReason { get; set; }
    }
}
