using LinqHelper;
using Models.DbModels;
using Models.DTOs;
using System.Collections.Generic;

namespace IBusinessServices
{
    public interface _IBusinessService
    {
    }

    public interface _IBusinessService<TDbEntity, TSummaryDTO, TDetailsDTO> : _IBusinessService
        where TDbEntity : _BaseEntity
    {
        DataSourceResult<T> GetAll<T>(DataSourceRequest dataSourceRequest, bool WithTracking = true);
        TDetailsDTO GetDetails(object Id, bool WithTracking = true);
        IEnumerable<TDetailsDTO> Insert(IEnumerable<TDetailsDTO> entities);
        IEnumerable<object> Delete(IEnumerable<object> Ids);
        IEnumerable<TDetailsDTO> Update(IEnumerable<TDetailsDTO> Entities);
        bool CheckIfExist(CheckUniqueDTO checkUniqueDTO);
    }

    #region Remove Complex Implementation To Ensure More Simplicity
    //public interface _IBusinessService<TDbEntity, TSummaryDTO> : _IBusinessService<TDbEntity, TSummaryDTO, TDbEntity>
    //   where TDbEntity : _BaseEntity
    //{
    //}

    //public interface _IBusinessService<TDbEntity> : _IBusinessService<TDbEntity, TDbEntity, TDbEntity>
    //    where TDbEntity : _BaseEntity
    //{
    //}
    #endregion

}
