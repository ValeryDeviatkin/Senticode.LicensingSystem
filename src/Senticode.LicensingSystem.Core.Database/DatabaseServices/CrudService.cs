using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using Senticode.LicensingSystem.Common.Interfaces.Services;
using Senticode.WPF.Tools.Core;
using Senticode.WPF.Tools.Core.Helpers;
using Unity;

namespace Senticode.LicensingSystem.Core.Database.DatabaseServices
{
    internal class CrudService<TEntity, TIdentifier> : ICrud<TEntity> where TEntity : class
    {
        private readonly PropertyInfo[] _identifierProperties = typeof(TIdentifier).GetPublicProperties();
        private readonly IUnityContainer _container;

        public CrudService(IUnityContainer container)
        {
            container.RegisterInstance(this);
            _container = container;

            using (var context = container.Resolve<IEntityContext<TEntity>>())
            {
                var dbEntities = context.Entities;
                
                foreach (var contextEntity in dbEntities)
                {
                    LocalEntities.Add(contextEntity);
                }
            }
        }
        
        public ObservableRangeCollection<TEntity> LocalEntities { get; } = new ObservableRangeCollection<TEntity>();

        public bool Add(TEntity entity)
        {
            bool result;

            using (var context = _container.Resolve<IEntityContext<TEntity>>())
            {
                var dbEntities = context.Entities;

                if (dbEntities.Find(GetKeyValues(entity)) == null)
                {
                    dbEntities.Add(entity);
                    context.SaveChanges();
                    LocalEntities.Add(entity);
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            entities = entities.ToArray();

            using (var context = _container.Resolve<IEntityContext<TEntity>>())
            {
                var dbEntities = context.Entities;
                dbEntities.AddRange(entities);
                context.SaveChanges();
            }

            LocalEntities.AddRange(entities);
        }

        public bool Delete(TEntity entity)
        {
            bool result;

            using (var context = _container.Resolve<IEntityContext<TEntity>>())
            {
                var dbEntities = context.Entities;
                var gottenEntity = dbEntities.Find(GetKeyValues(entity));

                if (gottenEntity == null)
                {
                    result = false;
                }
                else
                {
                    context.Entities.Remove(gottenEntity);
                    context.SaveChanges();
                    LocalEntities.Remove(entity);
                    result = true;
                }
            }
            
            return result;
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            entities = entities.ToArray();

            using (var context = _container.Resolve<IEntityContext<TEntity>>())
            {
                var dbEntities = context.Entities;

                foreach (var entity in entities)
                {
                    context.Entry(entity).State = EntityState.Deleted;
                }

                dbEntities.RemoveRange(entities);
                context.SaveChanges();
            }

            LocalEntities.RemoveRange(entities);
        }

        public bool Update(TEntity entity)
        {
            bool result;

            using (var context = _container.Resolve<IEntityContext<TEntity>>())
            {
                var dbEntities = context.Entities;

                if (dbEntities.Find(GetKeyValues(entity)) == null)
                {
                    result = false;
                }
                else
                {
                    dbEntities.AddOrUpdate(entity);
                    context.SaveChanges();
                    LocalEntities.Remove(entity);
                    LocalEntities.Add(entity);
                    result = true;
                }
            }

            return result;
        }

        private object[] GetKeyValues(TEntity entity)
        {
            var keyValues = new List<object>();

            foreach (var property in _identifierProperties)
            {
                keyValues.Add(property.GetValue(entity));
            }

            return keyValues.ToArray();
        }
    }
}