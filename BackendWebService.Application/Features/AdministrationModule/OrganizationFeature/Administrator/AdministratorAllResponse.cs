using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AdministratorAllResponse(
int UserId,
string Attributes,
OrganizationEnum organizationId,
StatusEnum Status,
RoleEnum MainRole): IConvertibleFromEntity<Administrator, AdministratorAllResponse>
{
public static AdministratorAllResponse FromEntity(Administrator Administrator) =>
new AdministratorAllResponse(
Administrator.UserId,
Administrator.Attributes,
Administrator.organizationId,
Administrator.Status,
Administrator.MainRole
);
}
