namespace Application.Features;
public record AddConsumerAccountRequest(
    int CompanyId,
    int SupplierId,
    bool IsApproved,
    DateTime? ApprovedDate,
    List<AddSupplierDocumentRequest> SupplierDocuments
);
