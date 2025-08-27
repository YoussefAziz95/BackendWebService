using Domain;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateConsumerDocumentRequest(
int ConsumerAccountId,
int PreDocumentId,
DateTime? ApprovedDate,
bool IsApproved,
string? Comment,
PreDocument PreDocument,
int? FileId);