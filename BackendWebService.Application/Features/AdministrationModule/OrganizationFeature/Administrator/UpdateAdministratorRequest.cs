using Application.Profiles;
using Domain;
using Domain.Enums;
using System.IO;

namespace Application.Features;
public record UpdateAdministratorRequest(
int UserId,
string Attributes,

OrganizationEnum OrganizationType,
StatusEnum Status,
RoleEnum MainRole):IConvertibleToEntity<Administrator>
{
public Administrator ToEntity() => new Administrator
{

UserId = UserId,
Attributes = Attributes,
OrganizationType = OrganizationType,
Status = Status
};
}
