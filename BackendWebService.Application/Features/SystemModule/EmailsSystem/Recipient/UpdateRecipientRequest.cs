using Application.Profiles;

namespace Application.Features;
public record UpdateRecipientRequest(
int ReceiverId,
int EmailId,
Actor Reciver,
EmailLog Email):IConvertibleToEntity<Recipient>
{
public Recipient ToEntity() => new Recipient
{
ReceiverId = ReceiverId,
EmailId = EmailId,
Reciver = Reciver.ToEntity(),
Email = Email.ToEntity()
};
}