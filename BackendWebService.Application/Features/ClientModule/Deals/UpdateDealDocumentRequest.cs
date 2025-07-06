namespace Application.Features;

public record UpdateDealDocumentRequest(
int Id,
int CriteriaId,
int FileId,
string? RichText);
