using AutoMapper;
using IBusinessServices;
using IHelperServices;
using IRepositories;
using Microsoft.Extensions.Localization;
using Models.DbModels;
using Models.DTOs;
using System;
using System.Linq;
using System.Text;

namespace BusinessServices
{
    public class LocalizationService : _BusinessService<Localization, LocalizationDetailsDTO, LocalizationDetailsDTO>, ILocalizationService
    {
        public LocalizationService(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer stringLocalizer, ISessionServices sessionServices) : base(unitOfWork, mapper, stringLocalizer, sessionServices)
        {
        }

        public string GetJson()
        {
            //var list = _mainDbContext.Localizations.Include(x => x.LocalizationCategory).AsNoTracking().ToList();
            //var result = "{" + string.Join(", ", list.GroupBy(x => x.LocalizationCategory).Select(x => "\"" + x.Key.Code + "\":{" + string.Join(", ", x.Select(s => "\"" + s.Key + "\":\"" + s.Value + "\"")) + "}")) + "}";
            var list = _UnitOfWork.Repository<Localization>().GetAllAsync(null, false).Result.Select(x => new { x.Key, x.Value }).ToList();
            StringBuilder resultx = new StringBuilder("{");
            foreach (var x in list)
            {
                resultx.Append('"').Append(x.Key.TrimEnd().TrimStart()).Append('"').Append(":").Append('"').Append(x.Value.TrimEnd().TrimStart()).Append('"').Append(",");
            }
            string xx = resultx.Append("}").ToString();
            string result = xx.Remove(xx.LastIndexOf(","), 1);
            return result;
        }

        public DateTime GetLastLocalizationUpdateTime()
        {
            return DateTime.Parse(_UnitOfWork.Repository<Localization>().GetAllAsync(null, false).Result.Select(x => x.CreatedOn)
                .Union(_UnitOfWork.Repository<Localization>().GetAllAsync(null, false).Result.Select(x => x.UpdatedOn)).Max().GetValueOrDefault().ToString());
        }
    }
}
