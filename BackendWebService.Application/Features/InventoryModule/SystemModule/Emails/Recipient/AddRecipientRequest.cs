using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddRecipientRequest(
int ReceiverId,
int EmailId,
AddActorRequest Reciver,
AddEmailLogRequest Email):IConvertibleToEntity<Recipient>
{
public Recipient ToEntity() => new Recipient
{
ReceiverId = ReceiverId,
EmailId = EmailId,
Reciver = Reciver.ToEntity(),
Email = Email.ToEntity()};
}