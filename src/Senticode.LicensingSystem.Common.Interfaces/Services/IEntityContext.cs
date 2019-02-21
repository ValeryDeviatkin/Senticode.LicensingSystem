using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Senticode.LicensingSystem.Common.Interfaces.Services
{
    public interface IEntityContext<TEntity> : IDisposable 
        where TEntity : class
    {
        DbSet<TEntity> Entities { get; set; }
        void SaveChanges();
        DbEntityEntry<TEntity> Entry(TEntity entity);
    }
}
