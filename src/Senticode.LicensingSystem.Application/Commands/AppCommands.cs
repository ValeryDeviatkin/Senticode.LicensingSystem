using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.WPF.Tools.Core;
using Unity;
using Senticode.LicensingSystem.Common.Models;

namespace Senticode.LicensingSystem.Application.Commands
{
    internal partial class AppCommands : AppCommandsBase
    {
        private readonly ICrud<Contract> _contractCrud;
        private readonly ICrud<Device> _deviceCrud;
        private readonly ICrud<Key> _keyCrud;
        private readonly ICrud<KeyUser> _keyUserCrud;
        private readonly ICrud<Organization> _organizationCrud;
        private readonly ICrud<Position> _positionCrud;
        private readonly ICrud<Product> _productCrud;
        private readonly ICrud<User> _userCrud;

        public AppCommands(
            IUnityContainer container,
            ICrud<Position> positionCrud,
            ICrud<Contract> contractCrud,
            ICrud<Device> deviceCrud,
            ICrud<Key> keyCrud,
            ICrud<KeyUser> keyUserCrud,
            ICrud<Organization> organizationCrud,
            ICrud<Product> productCrud,
            ICrud<User> userCrud
            )
        {
            container.RegisterInstance(this);

            _positionCrud = positionCrud;
            _contractCrud = contractCrud;
            _deviceCrud = deviceCrud;
            _keyCrud = keyCrud;
            _keyUserCrud = keyUserCrud;
            _organizationCrud = organizationCrud;
            _productCrud = productCrud;
            _userCrud = userCrud;
        }
    }
}
