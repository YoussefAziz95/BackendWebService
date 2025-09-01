using Application.Profiles;
using Domain;
using Domain.Enums;
using System.IO;

namespace Application.Features;
public record AddAdministratorRequest(
int UserId,
AddUserRequest User,
string Attributes,
OrganizationEnum OrganizationType,
StatusEnum Status,
RoleEnum MainRole):IConvertibleToEntity<Administrator>
{
public Administrator ToEntity() => new Administrator
{

UserId = UserId,
User = User,
Attributes = Attributes,
OrganizationType = OrganizationType,
Status = Status
};
}