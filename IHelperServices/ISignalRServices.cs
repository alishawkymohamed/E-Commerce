using System;
using System.Collections.Generic;

namespace IHelperServices
{
    public interface ISignalRServices : _IHelperService
    {
        IEnumerable<string> ActiveUsers { get; }
        Action<string> UserConnectedTask { get; set; }
        Action<string> UserDisconnectedTask { get; set; }

        void SignOut(string Username);

        void SendMessage(string userName, object message);

        void SendMessage(IEnumerable<string> userNames, object message);

        void DeleteMessage(string userName, object message);

        void DeleteMessage(IEnumerable<string> userNames, object message);

        void SendNotification(string userName, object notification);

        void SendNotification(IEnumerable<string> userNames, object notification);

        void DeleteNotification(string userName, object notification);

        void DeleteNotification(IEnumerable<string> userNames, object notification);

        void UserOnlineStatusChanged(string userName, int userId, bool isOnline);

        void UserOnlineStatusChanged(IEnumerable<string> userNames, int user, bool isOnline);
        void UserRoleUpdated(IEnumerable<string> userName);
    }
}