using Unity;

namespace Senticode.WPF.Tools.Core
{
    public class ServiceLocator
    {
        public static IUnityContainer Container { get; } = new UnityContainer();
    }
}
