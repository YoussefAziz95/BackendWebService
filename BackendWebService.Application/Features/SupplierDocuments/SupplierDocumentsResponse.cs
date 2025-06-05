namespace Application.Features;

public record SupplierDocumentsResponse(int? Id, string PreDocumentName, bool? IsApproved, int? FileId, int PreDocumentId);