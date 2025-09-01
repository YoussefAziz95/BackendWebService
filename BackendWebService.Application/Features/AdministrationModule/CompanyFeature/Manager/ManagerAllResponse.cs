using Application.Profiles;
using Domain;

namespace Application.Features;

public record ManagerAllResponse(
int OrganizationId,
string Name,
 string Position): IConvertibleFromEntity<Manager, ManagerAllResponse>

{
    public static ManagerAllResponse FromEntity(Manager Manager) =>
    new ManagerAllResponse(
    Manager.OrganizationId,
     Manager.Name,
    Manager.Position);
}