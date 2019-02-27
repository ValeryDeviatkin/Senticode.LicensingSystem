using Unity;

namespace Senticode.WPF.Tools.Core.Interfaces
{
    public interface IInitializer
    {
        IInitializer Initialize(IUnityContainer container);
    }
}
