using Models.DbModels;
using Models.DTOs;
using System;

namespace IBusinessServices
{
    public interface ILocalizationService : _IBusinessService<Localization, LocalizationDetailsDTO, LocalizationDetailsDTO>
    {
        string GetJson();
        DateTime GetLastLocalizationUpdateTime();
    }
}
