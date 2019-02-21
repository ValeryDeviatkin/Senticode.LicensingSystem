using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Senticode.LicensingSystem.Common.Interfaces.Services;

namespace Senticode.LicensingSystem.Core.Database.DatabaseServices
{
    internal class EntityContext<TEntity> : DbContext, IEntityContext<TEntity>
        where TEntity : class
    {
        public EntityContext() : base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\local-V97\\Documents\\LicensingDb.mdf;Integrated Security=True;Connect Timeout=30")
        {
        }

        public DbSet<TEntity> Entities { get; set; }

        public new void Dispose()
        {
            base.Dispose();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public DbEntityEntry<TEntity> Entry(TEntity entity)
        {
            return base.Entry(entity);
        }
    }
}
