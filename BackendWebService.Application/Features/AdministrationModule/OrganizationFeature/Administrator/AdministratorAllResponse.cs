using Domain.Enums;

namespace Application.Features;
public record AdministratorAllResponse(
int UserId,
string Attributes,
OrganizationEnum organizationId,
StatusEnum Status,
RoleEnum MainRole
 );
