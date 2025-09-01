using Application.Profiles;
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
int? FileId): IConvertibleToEntity<ConsumerDocument>
{
public ConsumerDocument ToEntity() => new ConsumerDocument
{
ConsumerAccountId = ConsumerAccountId,
PreDocumentId = PreDocumentId,
ApprovedDate= ApprovedDate,
IsApproved= IsApproved,
Comment = Comment,
PreDocument= PreDocument,
FileId= FileId
};
}