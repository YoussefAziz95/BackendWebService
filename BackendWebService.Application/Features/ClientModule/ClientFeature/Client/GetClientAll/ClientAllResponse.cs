using Application.Profiles;
using Domain.Enums;

namespace Application.Features;

public record ClientAllResponse(
int UserId,
RoleEnum Role,
StatusEnum Status,
 bool MFAEnabled = false) : IConvertibleFromEntity<Client, ClientAllResponse>
{
    public static ClientAllResponse FromEntity(Client Client) =>
    new ClientAllResponse(
    Client.UserId,
    Client.Role,
    Client.Status,
    Client.MFAEnabled);
}
