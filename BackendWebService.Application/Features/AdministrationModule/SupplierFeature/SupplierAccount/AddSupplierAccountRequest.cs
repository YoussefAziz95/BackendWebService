using Domain.Enums;

namespace Application.Features;
public record AddSupplierAccountRequest(
int CompanyId,
 int SupplierId,
bool IsApproved,
DateTime? ApprovedDate,
List<AddSupplierDocumentRequest> SupplierDocument
);
