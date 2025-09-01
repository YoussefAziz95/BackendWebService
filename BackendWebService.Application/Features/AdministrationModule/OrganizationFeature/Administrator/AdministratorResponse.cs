using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AdministratorResponse(
int UserId,
string Attributes,
OrganizationEnum organizationId,
StatusEnum Status,
RoleEnum MainRole) :IConvertibleFromEntity<Administrator, AdministratorResponse>
{
public static AdministratorResponse FromEntity(Administrator Administrator) =>
new AdministratorResponse(
Administrator.UserId,
Administrator.Attributes,
Administrator.organizationId,
Administrator.Status,
Administrator.MainRole
);
}
