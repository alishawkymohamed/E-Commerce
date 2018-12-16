using Microsoft.AspNetCore.Http;
using Models.DTOs;

namespace IHelperServices
{
    public interface ISessionServices : _IHelperService
    {
        HttpContext HttpContext { get; set; }
        int? UserId { get; }
        string UserName { get; }
        int? RoleId { get; }
        int? OrganizationId { get; }
        //string MachineName { get; }
        //string MachineIP { get; }
        //string Browser { get; }
        //string Url { get; }
        string Culture { get; }
        bool CultureIsArabic { get; }
        void SetAuthTicket(string username, AuthTicketDTO authTicket);
        AuthTicketDTO GetAuthTicket(string username);
    }
}
