using Domain.Enums;

namespace Application.Features;
public record UpdateContactRequest(
int OrganizationId,
string? Value,
string? Type,
ContactEnum? ContactType);
