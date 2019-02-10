using DbContexts.DatabaseExtensions;
using IHelperServices;
using IRepositories.IRepositories;
using LinqHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models.DbModels;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class _GenericRepository<TDbEntity> : _IGenericRepository<TDbEntity> where TDbEntity : _BaseEntity
    {
        protected readonly MainDbContext _Context;
        public readonly DbSet<TDbEntity> _DbSet;
        protected readonly ISessionServices _SessionServices;

        public _GenericRepository(MainDbContext mainDbContext, ISessionServices sessionServices)
        {
            _Context = mainDbContext;
            _SessionServices = sessionServices;
            _DbSet = _Context.Set<TDbEntity>();
        }

        public virtual IQueryable<TDbEntity> GetAll(Expression<Func<TDbEntity, bool>> expression, bool WithTracking = true)
        {
            if (WithTracking)
            {
                if (expression != null)
                    return _DbSet.Where(expression).AsQueryable();
                else
                    return _DbSet.AsQueryable();
            }
            else
            {
                if (expression != null)
                    return _DbSet.AsNoTracking().Where(expression).AsQueryable();
                else
                    return _DbSet.AsNoTracking().AsQueryable();
            }
        }

        public virtual TDbEntity GetById(object Id, bool WithTracking = true)
        {
            if (WithTracking)
            {
                return _DbSet.FindQuery(Id).FirstOrDefault();
            }
            else
            {
                return _DbSet.FindQuery(Id).AsNoTracking().FirstOrDefault();
            }
        }

        public virtual IEnumerable<TDbEntity> Insert(IEnumerable<TDbEntity> Entities)
        {
            int RecordsInserted;
            foreach (TDbEntity Entity in Entities)
            {
                if (typeof(IAuditableInsert).IsAssignableFrom(Entity.GetType()))
                {
                    (Entity as IAuditableInsert).CreatedOn = DateTimeOffset.Now;
                    (Entity as IAuditableInsert).CreatedBy = _SessionServices.UserId;
                }
                _DbSet.Add(Entity);
            }
            try
            {
                RecordsInserted =  _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RecordsInserted == Entities.Count() ? Entities : null;
        }

        public virtual IEnumerable<object> Delete(IEnumerable<object> Ids)
        {
            foreach (object Id in Ids)
            {
                TDbEntity ToBeRemoved = GetById(Id);
                if (typeof(IAuditableDelete).IsAssignableFrom(ToBeRemoved.GetType()))
                {
                    (ToBeRemoved as IAuditableDelete).DeletedOn = DateTimeOffset.Now;
                    (ToBeRemoved as IAuditableDelete).DeletedBy = _SessionServices.UserId;
                }
                else
                {
                    _DbSet.Remove(ToBeRemoved);
                }
            }
            try
            {
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ids;
        }

        public virtual TDbEntity Update(TDbEntity Entity)
        {
            EntityEntry<TDbEntity> DbEntry = _Context.Attach(_DbSet.Find(GetKey(Entity)));
            if (typeof(IAuditableUpdate).IsAssignableFrom(Entity.GetType()))
            {
                (Entity as IAuditableUpdate).UpdatedOn = DateTimeOffset.Now;
                (Entity as IAuditableUpdate).UpdatedBy = _SessionServices.UserId;
            }
            DbEntry.CurrentValues.SetValues(Entity);
            // await _Context.SaveChangesAsync();
            return Entity;
        }

        public virtual object[] GetKey<T>(T entity)
        {
            IEnumerable<string> keyNames = _Context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
                .Select(x => x.Name);
            List<object> result = new List<object>();

            foreach (string keyName in keyNames)
            {
                result.Add(entity.GetType().GetProperty(keyName).GetValue(entity, null));
            }
            return result.ToArray<object>();
        }

        private object[] GetKeyNames<T>(T entity)
        {
            return _Context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
                .Select(x => x.Name).ToArray();
        }

        public virtual TDbEntity Find(params object[] Ids)
        {
            return _Context.Find<TDbEntity>(Ids);
        }

        public virtual async Task<TDbEntity> FindAsync(params object[] Ids)
        {
            return await _Context.FindAsync<TDbEntity>(Ids);
        }

        public virtual async Task<TDbEntity> FirstOrDefaultAsync(Expression<Func<TDbEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _DbSet.FirstOrDefaultAsync(expression, cancellationToken);
        }
    }
}
