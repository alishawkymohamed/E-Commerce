using DbContexts.DatabaseExtensions;
using IHelperServices;
using IRepositories;
using IRepositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Models.DbModels;
using Models.DTOs;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainDbContext _Context;
        private Dictionary<string, object> repositories;
        private readonly ISessionServices _SessionServices;

        public UnitOfWork(MainDbContext mainDbContext, ISessionServices sessionServices)
        {
            _Context = mainDbContext;
            _SessionServices = sessionServices;
        }

        public bool IsExisted(CheckUniqueDTO checkUniqueDTO)
        {
            StringBuilder Query = new StringBuilder("SELECT COUNT(*) FROM ");
            Query.Append(checkUniqueDTO.TableName + " WHERE ");
            for (int i = 0; i < checkUniqueDTO.Fields.Length; i++)
            {
                Query.Append(checkUniqueDTO.Fields[i] + " LIKE '" + checkUniqueDTO.Values[i] + "'");
                if (checkUniqueDTO.Fields.Length - 1 != i)
                    Query.Append(" AND ");
            }
            string FinalQuery = Query.ToString();

            using (System.Data.Common.DbCommand command = _Context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = FinalQuery;
                _Context.Database.OpenConnection();
                object result = command.ExecuteScalar();
                _Context.Database.CloseConnection();
                return ((int)result) > 0;
            }
        }

        public void Run(Action action)
        {
            IDbContextTransaction localTransaction = _Context.Database.CurrentTransaction == null ? _Context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) : null;
            try
            {
                action.Invoke();
                localTransaction?.Commit();
            }
            catch (Exception ex)
            {
                _Context.Database.CurrentTransaction.Rollback();
                throw ex;
            }
        }

        public object Run(Func<object> method)
        {
            IDbContextTransaction localTransaction = _Context.Database.CurrentTransaction == null ? _Context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted) : null;
            try
            {
                object result = method();
                localTransaction?.Commit();
                return result;
            }
            catch (Exception ex)
            {
                _Context.Database.CurrentTransaction.Rollback();
                throw ex;
            }
        }

        public void RunSqlCommand(RawSqlString sql, params SqlParameter[] parameters)
        {
            Run(() =>
            {
                _Context.Database.ExecuteSqlCommand(sql, parameters);
            });
        }

        public int Save(bool? commit = true)
        {
            return _Context.SaveChanges(commit.Value);
        }

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _Context.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _Context.SaveChangesAsync(cancellationToken);
        }

        public _IGenericRepository<TDbEntity> Repository<TDbEntity>() where TDbEntity : _BaseEntity
        {
            if (repositories == null)
                repositories = new Dictionary<string, object>();

            var typeToInstantiate = typeof(_GenericRepository<TDbEntity>).Assembly.GetExportedTypes()
                .FirstOrDefault(t => t.BaseType == typeof(_GenericRepository<TDbEntity>));

            string type = typeof(TDbEntity).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryInstance = Activator.CreateInstance(typeToInstantiate, _Context, _SessionServices);
                repositories.Add(type, repositoryInstance);
            }
            return (_IGenericRepository<TDbEntity>)repositories[type];
        }

        //To Prevent Calling Database Entities OutSide Repository
        //public DbSet<TDbEntity> Set<TDbEntity>() where TDbEntity : _BaseEntity
        //{
        //    return this._Context.Set<TDbEntity>();
        //}
    }
}
