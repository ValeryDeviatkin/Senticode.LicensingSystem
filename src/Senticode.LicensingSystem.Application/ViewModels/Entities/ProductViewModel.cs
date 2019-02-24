using Senticode.LicensingSystem.Common.Models;
using Unity;

namespace Senticode.LicensingSystem.Application.ViewModels.Entities
{
    internal class ProductViewModel : EntityViewModelBase<Product>
    {
        #region ProductName property

        /// <summary>
        /// Gets or sets the ProductName value.
        /// </summary>
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }

        /// <summary>
        /// ProductName property data.
        /// </summary>
        private string _productName;

        #endregion

        public ProductViewModel(IUnityContainer container, Product entity) : base(container, entity)
        {
        }

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(ProductName):
                    {
                        if (string.IsNullOrWhiteSpace(ProductName)) return "NULL";
                        break;
                    }
                }

                return null;
            }
        }
    }
}
