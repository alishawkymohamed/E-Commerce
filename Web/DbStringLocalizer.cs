using DbContexts.DatabaseExtensions;
using IHelperServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace EnterpriseApplication
{
    public class DbStringLocalizer : IStringLocalizer, IHttpContext
    {
        protected readonly MainDbContext _DbContext;
        protected readonly IHttpContextAccessor _HttpContextAccessor;
        public DbStringLocalizer(MainDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _DbContext = dbContext;
            _HttpContextAccessor = httpContextAccessor;
        }
        public LocalizedString this[string name] => Translate(name);

        public LocalizedString this[string name, params object[] arguments] => Translate(name, arguments);

        public HttpContext HttpContext
        {
            get => _HttpContextAccessor.HttpContext;

            set => _HttpContextAccessor.HttpContext = value;
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private LocalizedString Translate(string name, params object[] arguments)
        {
            //var splittedName = name.Split('.');
            //var category = splittedName.Length >= 2 ? splittedName[0] : null;
            //var key = splittedName.Length >= 2 ? splittedName[1] : null;
            var value = _DbContext.Localizations.AsNoTracking().FirstOrDefault(x => x.Key == name)?.Value;
            var resourceNotFound = string.IsNullOrEmpty(value);
            value = value ?? name;
            if (arguments.Length > 0)
            {
                var culture = CultureInfo.CurrentCulture;
                var calendar = HttpContext.Request.Cookies["DefaultCalendar"];
                if (!string.IsNullOrEmpty(calendar))
                {
                    //if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar")
                    //{
                    if (calendar.ToLower() == "ummalqura")
                        culture = new CultureInfo("ar-SA");
                    else
                        culture = new CultureInfo("ar-EG");
                    //}
                }
                value = string.Format(culture, value, arguments);
            }
            return new LocalizedString(name, value, resourceNotFound);
        }


    }


    public class LocalizationHelper
    {
        private readonly MainDbContext _DbContext;
        public LocalizationHelper()
        {
            _DbContext = new MainDbContext();
        }

        public void GenerateLocalizationFilesForTypescript(IConfiguration Configuration)
        {
            try
            {
                var localizations = _DbContext.Localizations.ToList();
                var jsonAr = localizations.Select(x => new { x.Key, x.ValueAr }).ToList();
                var jsonEn = localizations.Select(x => new { x.Key, x.ValueEn }).ToList();
                var stringBuilder = new StringBuilder("{");
                foreach (var item in jsonAr)
                {
                    stringBuilder.Append('"').Append(item.Key).Append('"')
                        .Append(':').Append('"').Append(item.ValueAr).Append('"').Append(",");
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1).Append("}");

                var localizationPath = Configuration.GetValue("LocalizationSettings:LocalizationRelativePath", "");

                new FileInfo(localizationPath).Directory.Create();

                File.WriteAllText(localizationPath + "\\ar.json", stringBuilder.ToString());

                stringBuilder.Clear().Append("{");
                foreach (var item in jsonEn)
                {
                    stringBuilder.Append('"').Append(item.Key).Append('"')
                        .Append(':').Append('"').Append(item.ValueEn).Append('"').Append(",");
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1).Append("}");

                File.WriteAllText(localizationPath + "\\en.json", stringBuilder.ToString());
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _DbContext.Dispose();
            }
        }
    }
}
