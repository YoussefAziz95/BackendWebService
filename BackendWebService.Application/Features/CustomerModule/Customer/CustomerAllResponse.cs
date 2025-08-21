using Domain.Enums;

namespace Application.Features;
public record CustomerAllResponse(
int UserId,
RoleEnum Role,
StatusEnum Status,
bool MFAEnabled = false
  );
