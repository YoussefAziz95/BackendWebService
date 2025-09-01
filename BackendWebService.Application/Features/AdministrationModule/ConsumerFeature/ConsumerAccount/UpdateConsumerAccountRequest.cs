using Application.Profiles;
using Domain;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace Application.Features;
public record UpdateConsumerAccountRequest(
int CompanyId,
int ConsumerId,
bool IsApproved,
DateTime? ApprovedDate,
List<UpdateConsumerDocumentRequest> ConsumerDocument): IConvertibleToEntity<ConsumerAccount>
{
public ConsumerAccount ToEntity() => new ConsumerAccount
{
CompanyId = CompanyId,
ConsumerId = ConsumerId,
IsApproved = IsApproved,
ApprovedDate= ApprovedDate,
ConsumerDocuments = ConsumerDocument.Select(x => x.ToEntity()).ToList()
};
}