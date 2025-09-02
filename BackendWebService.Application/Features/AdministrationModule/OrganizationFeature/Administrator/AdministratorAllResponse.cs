using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AdministratorAllResponse(
int UserId,
string Attributes,
OrganizationEnum OrganizationType,
StatusEnum Status,
RoleEnum MainRole): IConvertibleFromEntity<Administrator, AdministratorAllResponse>
{
public static AdministratorAllResponse FromEntity(Administrator Administrator) =>
new AdministratorAllResponse(
Administrator.UserId,
Administrator.Attributes,
Administrator.OrganizationType,
Administrator.Status,
Administrator.MainRole
);
}
