using IBusinessServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.DTOs;
using System;
using System.Globalization;

namespace WebApi
{
    [Route("api/[controller]")]
    public class LocalizationController : _BaseController<Localization, LocalizationDetailsDTO, LocalizationDetailsDTO>
    {
        private readonly ILocalizationService _localizationService;
        public LocalizationController(ILocalizationService businessService) : base(businessService)
        {
            _localizationService = businessService;
        }

        [HttpGet]
        [Route("json/{culture}")]
        [AllowAnonymous]
        public string Json(string culture)
        {
            CultureInfo.CurrentCulture = string.IsNullOrEmpty(culture) ? CultureInfo.CurrentCulture : new CultureInfo(culture);
            //var json = _ILocalizationServices.GetJson();
            //return new FileContentResult(Encoding.UTF8.GetBytes(json), "application/json");
            return _localizationService.GetJson();
        }
        [HttpGet]
        [Route("GetLastUpDateTime")]
        [AllowAnonymous]
        public DateTime GetLastUpDateTime()
        {
            return _localizationService.GetLastLocalizationUpdateTime();
        }
    }
}