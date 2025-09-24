using Application.Contracts.Features;
using Application.Profiles;
using Domain.Enums;

namespace Application.Features;

public record AddClientRequest(
int UserId,
AddUserRequest User,
RoleEnum Role,
StatusEnum Status,
List<AddClientPropertyRequest> ClientProperties,
bool MFAEnabled = false) : IConvertibleToEntity<Client>, IRequest<int>
{
    public Client ToEntity() => new Client
    {
        UserId = UserId,
        User = User.ToEntity(),
        Role = Role,
        Status = Status,
        ClientProperties = ClientProperties.Select(x => x.ToEntity()).ToList(),
        MFAEnabled = MFAEnabled

    };
}