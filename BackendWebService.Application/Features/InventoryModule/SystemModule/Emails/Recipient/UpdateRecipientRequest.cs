using Application.Profiles;

namespace Application.Features;
public record UpdateRecipientRequest(
int ReceiverId,
int EmailId,
UpdateActorRequest Reciver,
UpdateEmailLogRequest Email):IConvertibleToEntity<Recipient>
{
public Recipient ToEntity() => new Recipient
{
ReceiverId = ReceiverId,
EmailId = EmailId,
Reciver = Reciver.ToEntity(),
Email = Email.ToEntity()
};
}