namespace Application.Features;

public record UpdateSupplierDocumentRequest(int Id, int? FileId, int UserId);