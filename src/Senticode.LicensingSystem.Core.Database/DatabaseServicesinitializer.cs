using Senticode.LicensingSystem.Common.Interfaces.Models;
using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.LicensingSystem.Core.Database.DatabaseServices;
using Senticode.WPF.Tools.Core.Interfaces;
using Senticode.LicensingSystem.Common.Models;
using Unity;
using Unity.Injection;

namespace Senticode.LicensingSystem.Core.Database
{
    public class DatabaseServicesinitializer : IInitializer
    {
        public IInitializer Initialize(IUnityContainer container)
        {
            container.RegisterType<IEntityContext<Position>, EntityContext<Position>>();
            container.RegisterType<IEntityContext<Contract>, EntityContext<Contract>>();
            container.RegisterType<IEntityContext<Device>, EntityContext<Device>>();
            container.RegisterType<IEntityContext<Key>, EntityContext<Key>>();
            container.RegisterType<IEntityContext<KeyUser>, EntityContext<KeyUser>>();
            container.RegisterType<IEntityContext<Organization>, EntityContext<Organization>>();
            container.RegisterType<IEntityContext<Product>, EntityContext<Product>>();
            container.RegisterType<IEntityContext<User>, EntityContext<User>>();

            container.RegisterSingleton<ICrud<Position>, CrudService<Position, IIdentifier>>(
                new InjectionConstructor(container));
            container.RegisterSingleton<ICrud<Contract>, CrudService<Contract, IIdentifier>>(
                new InjectionConstructor(container));
            container.RegisterSingleton<ICrud<Device>, CrudService<Device, IIdentifier>>(
                new InjectionConstructor(container));
            container.RegisterSingleton<ICrud<Key>, CrudService<Key, IIdentifier>>(
                new InjectionConstructor(container));
            container.RegisterSingleton<ICrud<KeyUser>, CrudService<KeyUser, IKeyUserIdentifier>>(
                new InjectionConstructor(container));
            container.RegisterSingleton<ICrud<Organization>, CrudService<Organization, IIdentifier>>(
                new InjectionConstructor(container));
            container.RegisterSingleton<ICrud<Product>, CrudService<Product, IIdentifier>>(
                new InjectionConstructor(container));
            container.RegisterSingleton<ICrud<User>, CrudService<User, IId>>(
                new InjectionConstructor(container));

            return this;
        }
    }
}
