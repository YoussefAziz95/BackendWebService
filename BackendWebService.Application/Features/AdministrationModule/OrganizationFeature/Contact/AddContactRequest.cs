using Domain.Enums;

namespace Application.Features;
public record AddContactRequest(
 int OrganizationId,
 string? Value,
 string? Type,
 ContactEnum? ContactType
);
