using IHelperServices;
using Microsoft.AspNetCore.Http;
using Models.DTOs;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Security.Claims;

namespace HelperServices
{
    public class SessionServices : _HelperService, ISessionServices
    {
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly IEncryptionServices _EncryptionServices;

        public SessionServices(IHttpContextAccessor httpContextAccessor, IEncryptionServices encryptionServices)
        {
            _HttpContextAccessor = httpContextAccessor;
            _EncryptionServices = encryptionServices;
        }

        public HttpContext HttpContext
        {
            get
            {
                return _HttpContextAccessor.HttpContext;
            }
            set
            {
                _HttpContextAccessor.HttpContext = value;
            }
        }

        public int? UserId
        {
            get
            {
                if (HttpContext.User == null)
                    return null;
                Claim claim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (claim == null)
                    return null;
                return int.Parse(claim.Value);
            }
        }

        public string UserName
        {
            get
            {
                if (HttpContext.User == null || HttpContext.User.Identity == null)
                    return null;
                return HttpContext.User.Identity.Name;
            }
        }

        public int? OrganizationId
        {
            get
            {
                if (HttpContext.User == null)
                    return null;
                Claim claim = HttpContext.User.FindFirst("CurrentRoleId");
                if (claim == null)
                    return null;
                return int.Parse(claim.Value);
            }
        }

        public int? RoleId
        {
            get
            {
                if (HttpContext.User == null)
                    return null;
                Claim claim = HttpContext.User.FindFirst("CurrentOrganizationId");
                if (claim == null)
                    return null;
                return int.Parse(claim.Value);
            }
        }

        //public string MachineName
        //{
        //    get
        //    {
        //        return string.Empty;
        //    }
        //}

        //public string MachineIP
        //{
        //    get
        //    {
        //        return string.Empty;
        //    }
        //}

        //public string Browser
        //{
        //    get
        //    {
        //        return string.Empty;
        //    }
        //}

        //public string Url
        //{
        //    get
        //    {
        //        return string.Empty;
        //    }
        //}

        public string Culture
        {
            get
            {
                return CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            }
        }

        public bool CultureIsArabic
        {
            get
            {
                return Culture == "ar";
            }
        }

        //public string ClaimTest { get { return GetClaim<string>("S"); } }

        public void SetAuthTicket(string username, AuthTicketDTO authTicket)
        {
            HttpContext.Session.SetString(username.ToUpper(), JsonConvert.SerializeObject(authTicket));
        }

        public AuthTicketDTO GetAuthTicket(string username)
        {
            string Auth = HttpContext.Session.GetString(username.ToUpper());
            if (Auth != null)
                return JsonConvert.DeserializeObject<AuthTicketDTO>(Auth);
            else
                return null;
        }

        #region Private Methods

        private T GetClaim<T>(string key, T defaultValue = default(T))
        {
            T result = defaultValue;
            string value = HttpContext.User.HasClaim(x => x.Type == key) ? HttpContext.User.FindFirst(key).Value : null;
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    Type t = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
                    result = (T)Convert.ChangeType(value, t);
                }
                catch
                {
                    result = defaultValue;
                }
            }
            return result;
        }

        private string SharedEncryptionKey { get; set; }

        private string EncryptionKey
        {
            get
            {
                string result = SharedEncryptionKey /*?? GetCookie<string>("_k", null, false)*/;
                if (result == null)
                {
                    result = Guid.NewGuid().ToString();
                    SharedEncryptionKey = result;
                    //SetCookie("_k", result, false);
                }
                return result;
            }
        }

        private void SetCookie<T>(string key, T value, bool encrypt = true)
        {
            string str = Convert.ToString(value);
            if (encrypt)
            {
                str = _EncryptionServices.EncryptString(str, EncryptionKey, key);
            }
            _HttpContextAccessor.HttpContext.Response.Cookies.Append(key, str);
        }

        private T GetCookie<T>(string key, T defaultValue = default(T), bool decrypt = true)
        {
            T result = defaultValue;
            string value = _HttpContextAccessor.HttpContext.Request.Cookies[key];
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    if (decrypt)
                    {
                        value = _EncryptionServices.DecryptString(value, EncryptionKey, key);
                    }
                    Type t = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
                    result = (T)Convert.ChangeType(value, t);
                }
                catch
                {
                    result = defaultValue;
                }
            }
            return result;
        }
        #endregion Private Methods
    }
}
