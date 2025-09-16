using Application.Profiles;
using Domain;

namespace Application.Features;
public record ManagerResponse(
   int OrganizationId,
    string Name,
    string Position) : IConvertibleFromEntity<Manager, ManagerResponse>
{
    public static ManagerResponse FromEntity(Manager manager) =>
        new ManagerResponse(
            manager.OrganizationId,
            manager.Name,
            manager.Position);
}