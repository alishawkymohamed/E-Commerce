using AutoMapper;
using HelperServices.LinqHelpers;
using IBusinessServices;
using IHelperServices;
using IRepositories;
using LinqHelper;
using Microsoft.Extensions.Localization;
using Models.DbModels;
using Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BusinessServices
{
    public class LookupServices : ILookupService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _Mapper;
        protected readonly IStringLocalizer _StringLocalizer;
        protected readonly ISessionServices _SessionServices;

        public LookupServices(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer stringLocalizer, ISessionServices sessionServices/*, ITransactionServices transactionServices,*/ /*IOldTransactionServices oldTransactionServices*/)
        {
            _unitOfWork = unitOfWork;
            _Mapper = mapper;
            _StringLocalizer = stringLocalizer;
            _SessionServices = sessionServices;
        }

        public IEnumerable<Lookup> Get(string Type, string SearchText, DataSourceRequest dataSourceRequest, Dictionary<string, object> args, object[] ids = null)
        {
            args = args ?? new Dictionary<string, object>();
            IEnumerable<Lookup> result = null;
            switch (Type.ToLower())
            {
                case "categories":
                    result = _unitOfWork.Repository<Category>().GetAll()
                        //.Where(x => string.IsNullOrEmpty(SearchText) || x.CategoryNameAr.Contains(SearchText) || x.CategoryNameEn.Contains(SearchText) || x.CategoryCode.Contains(SearchText))
                        //.Where(x => ids == null || ids.Select(id => Convert.ToInt32(id)).Contains(x.PermissionId))
                        .ToDataSourceResult(dataSourceRequest, true).Data
                        .Select(x => new Lookup
                        {
                            Id = x.CategoryId,
                            TextAr = x.CategoryNameAr,
                            TextEn = x.CategoryNameEn
                        }).OrderBy(x => x.Id);
                    break;
                //    case "permissions":
                //        result = _unitOfWork.Repository<Permission>().GetAllAsync().Result
                //            .Where(x => string.IsNullOrEmpty(SearchText) || x.PermissionNameAr.Contains(SearchText) || x.PermissionNameEn.Contains(SearchText) || x.PermissionCode.Contains(SearchText))
                //            .Where(x => ids == null || ids.Select(id => Convert.ToInt32(id)).Contains(x.PermissionId))
                //            .ToDataSourceResult(dataSourceRequest, true).Data
                //            .Select(x => new Lookup
                //            {
                //                Id = x.PermissionId,
                //                Text = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ? (string.IsNullOrEmpty(x.PermissionNameAr) ? x.PermissionNameEn : x.PermissionNameAr) : (string.IsNullOrEmpty(x.PermissionNameEn) ? x.PermissionNameAr : x.PermissionNameEn),
                //            }).OrderBy(x => x.Text);
                //        break;

                //    case "genders":
                //        result = _unitOfWork.Repository<Gender>().GetAllAsync().Result
                //            .Where(x => string.IsNullOrEmpty(SearchText) || x.GenderNameAr.Contains(SearchText) || x.GenderNameEn.Contains(SearchText))
                //            .Where(x => ids == null || ids.Select(id => Convert.ToInt32(id)).Contains(x.GenderId))
                //            .ToDataSourceResult(dataSourceRequest, true).Data
                //            .Select(x => new Lookup
                //            {
                //                Id = x.GenderId,
                //                Text = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ? (string.IsNullOrEmpty(x.GenderNameAr) ? x.GenderNameEn : x.GenderNameAr) : (string.IsNullOrEmpty(x.GenderNameEn) ? x.GenderNameAr : x.GenderNameEn)
                //            }).OrderBy(x => x.Text);
                //        break;

                //    case "jobtitles":
                //        result = _unitOfWork.Repository<JobTitle>().GetAllAsync().Result
                //            .Where(x => string.IsNullOrEmpty(SearchText) || x.JobTitleNameAr.Contains(SearchText) || x.JobTitleNameEn.Contains(SearchText))
                //            .Where(x => ids == null || ids.Select(id => Convert.ToInt32(id)).Contains(x.JobTitleId))
                //            .ToDataSourceResult(dataSourceRequest, true).Data
                //            .Select(x => new Lookup
                //            {
                //                Id = x.JobTitleId,
                //                Text = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ? (string.IsNullOrEmpty(x.JobTitleNameAr) ? x.JobTitleNameEn : x.JobTitleNameAr) : (string.IsNullOrEmpty(x.JobTitleNameEn) ? x.JobTitleNameAr : x.JobTitleNameEn)
                //            }).OrderBy(x => x.Text);
                //        break;

                //    case "nationalities":
                //        result = _unitOfWork.Repository<Nationality>().GetAllAsync().Result
                //            .Where(x => string.IsNullOrEmpty(SearchText) || x.NationalityNameAr.Contains(SearchText) || x.NationalityNameEn.Contains(SearchText))
                //            .Where(x => ids == null || ids.Select(id => Convert.ToInt32(id)).Contains(x.NationalityId))
                //            .ToDataSourceResult(dataSourceRequest, true).Data
                //            .Select(x => new Lookup
                //            {
                //                Id = x.NationalityId,
                //                Text = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ? (string.IsNullOrEmpty(x.NationalityNameAr) ? x.NationalityNameEn : x.NationalityNameAr) : (string.IsNullOrEmpty(x.NationalityNameEn) ? x.NationalityNameAr : x.NationalityNameEn)
                //            }).OrderBy(x => x.Text);
                //        break;

                //    case "organizations":
                //        result = _unitOfWork.Repository<Organization>().GetAllAsync().Result
                //            .Where(x => x.IsActive)
                //            .Where(x => string.IsNullOrEmpty(SearchText) || x.OrganizationNameAr.Contains(SearchText) || x.OrganizationNameEn.Contains(SearchText) || x.Code.ToString().Contains(SearchText))
                //            .Where(x => ids == null || ids.Select(id => Convert.ToInt32(id)).Contains(x.OrganizationId))
                //            .ToDataSourceResult(dataSourceRequest, true).Data
                //            .Select(x => new Lookup
                //            {
                //                Id = x.OrganizationId,
                //                Text = x.Code.ToString() + " - " + (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ? (string.IsNullOrEmpty(x.OrganizationNameAr) ? x.OrganizationNameEn : x.OrganizationNameAr) : (string.IsNullOrEmpty(x.OrganizationNameEn) ? x.OrganizationNameAr : x.OrganizationNameEn)),
                //                Additional = new LookupAdditional
                //                {
                //                    Description = x.FullPath
                //                }
                //            }).OrderBy(x => x.Text);
                //        break;

                //    case "roles":
                //        result = _unitOfWork.Repository<Role>().GetAllAsync().Result
                //            .Where(x => string.IsNullOrEmpty(SearchText) || x.RoleNameAr.Contains(SearchText) || x.RoleNameEn.Contains(SearchText))
                //            .Where(x => ids == null || ids.Select(id => Convert.ToInt32(id)).Contains(x.RoleId))
                //            .ToDataSourceResult(dataSourceRequest, true).Data
                //            .Select(x => new Lookup
                //            {
                //                Id = x.RoleId,
                //                Text = x.RoleName,
                //            }).OrderBy(x => x.Text);
                //        break;


                //    case "notificationtypes":
                //        result = _unitOfWork.Repository<NotificationType>().GetAllAsync().Result
                //            .Where(x => string.IsNullOrEmpty(SearchText) || x.NotificationTypeNameAr.Contains(SearchText) || x.NotificationTypeNameEn.Contains(SearchText))
                //            .Where(x => ids == null || ids.Select(id => Convert.ToInt32(id)).Contains(x.NotificationTypeId))
                //            .ToDataSourceResult(dataSourceRequest, true).Data
                //            .Select(x => new Lookup
                //            {
                //                Id = x.NotificationTypeId,
                //                Text = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ? (string.IsNullOrEmpty(x.NotificationTypeNameAr) ? x.NotificationTypeNameEn : x.NotificationTypeNameAr) : (string.IsNullOrEmpty(x.NotificationTypeNameEn) ? x.NotificationTypeNameAr : x.NotificationTypeNameEn)
                //            });
                //        break;

                //    case "users":
                //        OrganizationId = args.GetValue<int?>("OrganizationId");
                //        result = _unitOfWork.Repository<User>().GetAllAsync().Result
                //            .Where(x => !OrganizationId.HasValue || x.UserRoles.Any(ur => ur.OrganizationId == OrganizationId))
                //            .Where(x => string.IsNullOrEmpty(SearchText) || x.FullNameAr.Contains(SearchText) || x.FullNameEn.Contains(SearchText) || x.Email.StartsWith(SearchText))
                //            .Where(x => ids == null || ids.Select(id => Convert.ToInt32(id)).Contains(x.UserId))
                //            .ToDataSourceResult(dataSourceRequest, true).Data
                //            .Select(x => new Lookup
                //            {
                //                Id = x.UserId,
                //                Text = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ? (string.IsNullOrEmpty(x.FullNameAr) ? x.FullNameEn : x.FullNameAr) : (string.IsNullOrEmpty(x.FullNameEn) ? x.FullNameAr : x.FullNameEn)
                //                //Additional = new LookupAdditional { ImageId = x.ProfileImageFileId, Data = new { CanReceiveNotification = x.NotificationByMail || x.NotificationBySMS } }
                //            }).OrderBy(x => x.Text);
                //        break;

                //    case "permissioncategories":
                //        result = _unitOfWork.Repository<PermissionCategory>().GetAllAsync().Result.ToDataSourceResult(dataSourceRequest, true).Data
                //            .Select(x => new Lookup
                //            {
                //                Id = x.PermissionCategoryId,
                //                Text = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ? (string.IsNullOrEmpty(x.PermissionCategoryNameAr) ? x.PermissionCategoryNameEn : x.PermissionCategoryNameAr) : (string.IsNullOrEmpty(x.PermissionCategoryNameEn) ? x.PermissionCategoryNameAr : x.PermissionCategoryNameEn)
                //            }).OrderBy(x => x.Text);
                //        break;

                default:
                    throw new BusinessException("No lookup defined for this type");
            }
            return result;
        }
    }
}
