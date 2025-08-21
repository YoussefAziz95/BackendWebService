using Domain.Enums;

namespace Application.Features;
public record SupplierAccountResponse(
int CompanyId,
 int SupplierId,
bool IsApproved,
DateTime? ApprovedDate,
List<AddSupplierDocumentRequest> SupplierDocument
);