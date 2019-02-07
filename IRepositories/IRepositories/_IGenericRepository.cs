using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace IRepositories.IRepositories
{
    public interface _IGenericRepository<TDbEntity> where TDbEntity : _BaseEntity
    {
        Task<IQueryable<TDbEntity>> GetAllAsync(Expression<Func<TDbEntity, bool>> expression = null, bool WithTracking = true);
        Task<TDbEntity> GetById(object Id, bool WithTracking = true);
        Task<IEnumerable<TDbEntity>> Insert(IEnumerable<TDbEntity> Entities);
        Task<IEnumerable<object>> Delete(IEnumerable<object> Ids);
        TDbEntity Update(TDbEntity Entity);
        object[] GetKey<T>(T entity);
        TDbEntity Find(params object[] Ids);
        Task<TDbEntity> FindAsync(params object[] Ids);
        Task<TDbEntity> FirstOrDefaultAsync(Expression<Func<TDbEntity, bool>> Predicate, CancellationToken cancellationToken = new CancellationToken());
    }
}
