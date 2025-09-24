using Application.Profiles;

namespace Application.Features;
public record RecipientResponse(
int ReceiverId,
int EmailId,
ActorResponse Reciver,
EmailLogResponse Email) : IConvertibleFromEntity<Recipient, RecipientResponse>
{
    public static RecipientResponse FromEntity(Recipient Recipient) =>
    new RecipientResponse(
    Recipient.ReceiverId,
    Recipient.EmailId,
    ActorResponse.FromEntity(Recipient.Reciver),
    EmailLogResponse.FromEntity(Recipient.Email));
}
