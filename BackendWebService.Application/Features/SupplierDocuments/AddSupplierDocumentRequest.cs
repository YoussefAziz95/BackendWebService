namespace Application.Features;

public record AddSupplierDocumentRequest(int UserId, int CompanyId, int FileId, int PreDocumentId);