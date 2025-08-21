using Domain;

namespace Application.Features;

public record DealDocumentResponse(
int? Score,
string? Comment,
string? RichText,
int? StatusId,
int DealId,
int CriteriaId,
int FileId,
int FileFieldValidatorId,
Deal Deal,
Criteria Criteria,
FileLog File,
FileFieldValidator FileFieldValidator
    );