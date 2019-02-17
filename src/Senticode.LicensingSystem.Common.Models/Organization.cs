﻿using Senticode.LicensingSystem.Common.Interfaces.Models;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class Organization : ModelBase, IIdentifier
    {
        int IIdentifier.Id { get; set; }
        public string Name { get; set; }
    }
}
