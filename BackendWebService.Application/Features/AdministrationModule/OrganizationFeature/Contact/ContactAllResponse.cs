using Domain.Enums;

namespace Application.Features;
public record ContactAllResponse(
 int OrganizationId,
 string? Value,
 string? Type,
 ContactEnum? ContactType
    );
