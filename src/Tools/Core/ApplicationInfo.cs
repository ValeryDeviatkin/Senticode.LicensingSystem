using System.Reflection;
using System.Windows;

namespace Senticode.WPF.Tools.Core
{
    /// <summary>
    ///     Helper class to display application information.
    /// </summary>
    public class ApplicationInfo
    {
        public ApplicationInfo()
        {
            var assembly = Application.Current.GetType().GetTypeInfo().Assembly;
            Version = assembly.GetName().Version.ToString();
        }

        /// <summary>
        ///     Get current assembly version.
        /// </summary>
        public string Version { get; }
    }
}