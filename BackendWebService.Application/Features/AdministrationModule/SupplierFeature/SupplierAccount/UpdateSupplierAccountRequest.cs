using Domain.Enums;

namespace Application.Features;
public record UpdateSupplierAccountRequest(
int CompanyId,
 int SupplierId,
bool IsApproved,
DateTime? ApprovedDate,
List<AddSupplierDocumentRequest> SupplierDocument
 );
