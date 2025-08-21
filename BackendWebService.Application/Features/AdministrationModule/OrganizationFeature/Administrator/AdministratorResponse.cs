using Domain.Enums;

namespace Application.Features;
public record AdministratorResponse(
int UserId,
string Attributes,
OrganizationEnum organizationId,
StatusEnum Status,
RoleEnum MainRole
);
