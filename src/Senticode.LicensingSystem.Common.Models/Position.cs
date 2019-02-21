using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Senticode.WPF.Tools.MVVM;

namespace Senticode.LicensingSystem.Common.Models
{
    public class Position : ModelBase
    {
        #region PositionName property

        /// <summary>
        /// Gets or sets the PositionName value.
        /// </summary>
        [Key]
        public string PositionName
        {
            get { return _positionName; }
            set { SetProperty(ref _positionName, value); }
        }

        /// <summary>
        /// PositionName property data.
        /// </summary>
        private string _positionName;

        #endregion
        //Key


        #region KeyUsers property

        /// <summary>
        /// Gets or sets the KeyUsers value.
        /// </summary>
        public ICollection<KeyUser> KeyUsers
        {
            get { return _keyUsers; }
            set { SetProperty(ref _keyUsers, value); }
        }

        /// <summary>
        /// KeyUsers property data.
        /// </summary>
        private ICollection<KeyUser> _keyUsers;

        #endregion

        public Position()
        {
            KeyUsers = new List<KeyUser>();
        }
    }
}
