using IRepositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using Models.DTOs;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IUnitOfWork
    {
        bool IsExisted(CheckUniqueDTO checkUniqueDTO);
        void RunSqlCommand(RawSqlString sql, params SqlParameter[] parameters);
        int Save(bool? commit = true);
        _IGenericRepository<TDbEntity> Repository<TDbEntity>() where TDbEntity : _BaseEntity;
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        void Run(System.Action action);
        object Run(System.Func<object> method);
        //DbSet<TDbEntity> Set<TDbEntity>() where TDbEntity : _BaseEntity;
    }
}
