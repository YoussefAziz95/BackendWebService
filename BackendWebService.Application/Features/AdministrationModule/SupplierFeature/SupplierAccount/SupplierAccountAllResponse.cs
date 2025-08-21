using Domain.Enums;

namespace Application.Features;
public record SupplierAccountAllResponse(
int CompanyId,
 int SupplierId,
bool IsApproved,
DateTime? ApprovedDate

 );
