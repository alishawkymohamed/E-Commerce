using AutoMapper;
using AutoMapper.QueryableExtensions;
using HelperServices.LinqHelpers;
using IBusinessServices;
using IHelperServices;
using IRepositories;
using LinqHelper;
using Microsoft.Extensions.Localization;
using Models.DbModels;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessServices
{
    public abstract class _BusinessService : _IBusinessService
    {
        protected readonly IUnitOfWork _UnitOfWork;
        protected readonly IMapper _Mapper;
        protected readonly IStringLocalizer _StringLocalizer;
        protected readonly ISessionServices _SessionServices;

        public ISessionServices SessionServices => _SessionServices;

        public _BusinessService(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer stringLocalizer, ISessionServices sessionServices)
        {
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _StringLocalizer = stringLocalizer;
            _SessionServices = sessionServices;
        }

    }

    public abstract class _BusinessService<TDbEntity, TSummaryDTO, TDetailsDTO> : _BusinessService, _IBusinessService<TDbEntity, TSummaryDTO, TDetailsDTO>
             where TDbEntity : _BaseEntity
             where TSummaryDTO : class
             where TDetailsDTO : class
    {
        public _BusinessService(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer stringLocalizer, ISessionServices sessionServices) : base(unitOfWork, mapper, stringLocalizer, sessionServices) { }

        public virtual DataSourceResult<T> GetAll<T>(DataSourceRequest dataSourceRequest, bool WithTracking = true)
        {
            IQueryable query = _UnitOfWork.Repository<TDbEntity>().GetAllAsync(null, WithTracking).Result;
            // Global Query Filter Added
            //if (typeof(IAuditableDelete).IsAssignableFrom(typeof(TDbEntity)))
            //{
            //    query = query.Where(x => !((IAuditableDelete)x).DeletedOn.HasValue);
            //}
            if (typeof(TDbEntity) == typeof(T))
                return query.Cast<T>().ToDataSourceResult(dataSourceRequest);
            else
                return query.ProjectTo<T>(_Mapper.ConfigurationProvider, _SessionServices).ToDataSourceResult(dataSourceRequest);
        }

        public virtual TDetailsDTO GetDetails(object Id, bool WithTracking = true)
        {
            if (Id == null)
                return null;

            TypeMap Mapping = _Mapper.ConfigurationProvider.FindTypeMapFor(typeof(TDbEntity), typeof(TDetailsDTO));
            if (Mapping == null)
                Mapping = _Mapper.ConfigurationProvider.ResolveTypeMap(typeof(TDbEntity), typeof(TDetailsDTO));

            Task<TDbEntity> EntityObject = _UnitOfWork.Repository<TDbEntity>().GetById(Id, WithTracking);
            if (typeof(TDbEntity) == typeof(TDetailsDTO))
                return EntityObject as TDetailsDTO;
            else
                return _Mapper.Map(EntityObject, typeof(TDbEntity), typeof(TDetailsDTO)) as TDetailsDTO;
        }

        public virtual IEnumerable<TDetailsDTO> Insert(IEnumerable<TDetailsDTO> entities)
        {
            List<TDbEntity> TDbEntities = entities.AsQueryable().ProjectTo<TDbEntity>(_Mapper.ConfigurationProvider, _SessionServices).ToList();
            Task<IEnumerable<TDbEntity>> ToBereturned = _UnitOfWork.Repository<TDbEntity>().Insert(TDbEntities);
            return _Mapper.Map(ToBereturned.Result, typeof(IEnumerable<TDbEntity>), typeof(IEnumerable<TDetailsDTO>)) as IEnumerable<TDetailsDTO>;
        }

        public virtual IEnumerable<object> Delete(IEnumerable<object> Ids)
        {
            return _UnitOfWork.Repository<TDbEntity>().Delete(Ids).Result;
        }

        public virtual IEnumerable<TDetailsDTO> Update(IEnumerable<TDetailsDTO> Entities)
        {
            int RecordsUpdated;
            foreach (TDetailsDTO Entity in Entities)
            {
                //To Copy Data not Sent From and To UI
                object[] PrimaryKeysValues = _UnitOfWork.Repository<TDbEntity>().GetKey<TDbEntity>(_Mapper.Map(Entity, typeof(TDetailsDTO), typeof(TDbEntity)) as TDbEntity);
                TDbEntity OldEntity = _UnitOfWork.Repository<TDbEntity>().Find(PrimaryKeysValues);
                object MappedEntity = _Mapper.Map(Entity, OldEntity, typeof(TDetailsDTO), typeof(TDbEntity));
                _UnitOfWork.Repository<TDbEntity>().Update(MappedEntity as TDbEntity);
            }
            try
            {
                RecordsUpdated = _UnitOfWork.Save(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RecordsUpdated == Entities.Count() ? Entities : null;
        }

        public bool CheckIfExist(CheckUniqueDTO checkUniqueDTO)
        {
            return _UnitOfWork.IsExisted(checkUniqueDTO);
        }
    }


    #region Remove Complex Implementation To Ensure More Simplicity
    //public abstract class _BusinessService<TDbEntity, TSummaryDTO> : _BusinessService<TDbEntity, TSummaryDTO, TSummaryDTO>, _IBusinessService<TDbEntity, TSummaryDTO>
    //         where TDbEntity : _BaseEntity
    //{
    //    public _BusinessService(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer stringLocalizer, ISessionServices sessionServices) : base(unitOfWork, mapper, stringLocalizer, sessionServices) { }
    //}

    //public abstract class _BusinessService<TDbEntity> : _BusinessService<TDbEntity, TDbEntity, TDbEntity>, _IBusinessService<TDbEntity>
    //         where TDbEntity : _BaseEntity
    //{
    //    public _BusinessService(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer stringLocalizer, ISessionServices sessionServices) : base(unitOfWork, mapper, stringLocalizer, sessionServices) { }
    //}
    #endregion
}
