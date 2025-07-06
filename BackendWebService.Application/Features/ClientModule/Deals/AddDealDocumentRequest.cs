namespace Application.Features;

public record AddDealDocumentRequest(
int CriteriaId,
int FileId,
string? RichText);