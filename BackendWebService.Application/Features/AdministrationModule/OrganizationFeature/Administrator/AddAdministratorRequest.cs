using Domain.Enums;

namespace Application.Features;
public record AddAdministratorRequest(
int UserId,
string Attributes,
OrganizationEnum organizationId,
StatusEnum Status,
RoleEnum MainRole
);