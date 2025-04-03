using Application.Model.Notifications;
using System.Collections.Generic;

namespace Application.Contracts.Persistence.Identities
{
    public interface IClientRepository
    {
        public static IList<UserInfo> _users { get; set; }
        public static UserInfo _userInfo { get; set; }
    }
}
