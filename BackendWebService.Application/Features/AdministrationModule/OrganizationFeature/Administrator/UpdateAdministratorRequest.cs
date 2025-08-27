using Domain.Enums;

namespace Application.Features;
public record UpdateAdministratorRequest(
int UserId,
string Attributes,
OrganizationEnum organizationId,
StatusEnum Status,
RoleEnum MainRole);
