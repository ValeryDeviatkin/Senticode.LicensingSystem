using System.Collections.Generic;
using System.Globalization;

namespace Senticode.LicensingSystem.Common.Interfaces.Services
{
    public interface ILocalize
    {
        CultureInfo CultureContext { get; set; }
        List<CultureInfo> AvailableImplementation { get; }
    }
}