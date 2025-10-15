using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record AddAdministratorRequest(
int UserId,
string Username,
string Attributes,
OrganizationEnum OrganizationType,
StatusEnum Status,
RoleEnum MainRole) : IConvertibleToEntity<Administrator>, IRequest<int>
{
    public Administrator ToEntity() => new Administrator
    {
        UserId = UserId,
        Attributes = Attributes,
        OrganizationType = OrganizationType,
        Status = Status
    };
}