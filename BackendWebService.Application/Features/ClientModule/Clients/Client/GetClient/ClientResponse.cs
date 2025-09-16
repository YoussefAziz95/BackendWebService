using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record ClientResponse(
int UserId,
UserResponse User,
RoleEnum Role,
StatusEnum Status,
List<ClientPropertyResponse> ClientProperties,
bool MFAEnabled = false) : IConvertibleFromEntity<Client, ClientResponse>
{
    public static ClientResponse FromEntity(Client Client) =>
    new ClientResponse(
    Client.UserId,
    UserResponse.FromEntity(Client.User),
    Client.Role,
    Client.Status,
    Client.ClientProperties.Select(ClientPropertyResponse.FromEntity).ToList(),
    Client.MFAEnabled);
}
