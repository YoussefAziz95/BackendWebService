using Domain.Enums;

namespace Application.Features;
public record SupplierAllResponse(
 int OrganizationId,
 decimal? Rating,
 string? BankAccount,
 StatusEnum Status
 );
