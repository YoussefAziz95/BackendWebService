using Domain.Enums;

namespace Application.Features;
public record ContactResponse(
 int OrganizationId,
 string? Value,
 string? Type,
 ContactEnum? ContactType
);