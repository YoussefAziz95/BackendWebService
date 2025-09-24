using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;
namespace Application.Features;
public record UpdateAdministratorRequest(
int UserId,
string Attributes,
UpdateUserRequest User,
OrganizationEnum OrganizationType,
StatusEnum Status,
RoleEnum MainRole) : IConvertibleToEntity<Administrator>, IRequest<int>
{
    public Administrator ToEntity() => new Administrator
    {

        UserId = UserId,
        User = User.ToEntity(),
        Attributes = Attributes,
        OrganizationType = OrganizationType,
        Status = Status
    };
}
