namespace Senticode.WPF.Tools.Core
{
    public class AppSettingsBase
    {
        //public AppSettingsBase(IUnityContainer container)
        //{
        //    container.RegisterInstance(this);
        //}
        
        public ApplicationInfo ApplicationInfo { get; } = new ApplicationInfo();
    }
}
