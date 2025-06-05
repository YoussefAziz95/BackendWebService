namespace Application.Features;

public record SupplierDocumentResponse(int Id, int SupplierId, string SupplierName, int PreDocumentId, string PreDocumentName, string DocUrl, bool IsActive, bool IsDeleted, DateTime CreatedDate, DateTime? UpdateDate);