namespace Application.Features;

public record DealDocumentResponse(
int Id,
int Score,
string? RichText,
int DealId,
int CriteriaId,
int FileId,
int FileFieldValidatorId);