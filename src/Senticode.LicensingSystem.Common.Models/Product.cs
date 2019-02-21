using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class Product : ModelBase
    {
        #region ProductName property

        /// <summary>
        /// Gets or sets the ProductName value.
        /// </summary>
        [Key]
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
        //Key


        #region Keys property

        /// <summary>
        /// Gets or sets the Keys value.
        /// </summary>
        public ICollection<Key> Keys
        {
            get { return _keys; }
            set { SetProperty(ref _keys, value); }
        }

        /// <summary>
        /// Keys property data.
        /// </summary>
        private ICollection<Key> _keys;

        #endregion

        public Product()
        {
            Keys = new List<Key>();
        }
    }
}
