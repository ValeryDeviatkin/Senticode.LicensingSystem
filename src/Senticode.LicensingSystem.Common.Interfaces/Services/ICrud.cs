using System.Collections.Generic;
using Senticode.WPF.Tools.Core;

namespace Senticode.LicensingSystem.Common.Interfaces.Services
{
    public interface ICrud<TEntity> where TEntity : class
    {
        bool Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        bool Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        bool Update(TEntity entity, object[] oldKeyValues);
        ObservableRangeCollection<TEntity> LocalEntities { get; }
        object[] GetKeyValues(TEntity entity);
    }
}
