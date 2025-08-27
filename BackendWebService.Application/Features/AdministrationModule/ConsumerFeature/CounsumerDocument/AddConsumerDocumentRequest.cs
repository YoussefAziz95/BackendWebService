using Domain;

namespace Application.Features;
public record AddConsumerDocumentRequest(
int ConsumerAccountId,
int PreDocumentId,
DateTime? ApprovedDate,
bool IsApproved,
string? Comment,
PreDocument PreDocument,
int? FileId);
