using Application.Model.Notifications;

namespace Application.Contracts.Persistences;

public interface IClientRepository
{
    public static IList<UserInfo> _users { get; set; }
    public static UserInfo _userInfo { get; set; }
}
