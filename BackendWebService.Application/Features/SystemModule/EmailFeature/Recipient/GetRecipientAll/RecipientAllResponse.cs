using Application.Profiles;

namespace Application.Features;
public record RecipientAllResponse(
int ReceiverId,
int EmailId) : IConvertibleFromEntity<Recipient, RecipientAllResponse>
{
    public static RecipientAllResponse FromEntity(Recipient Recipient) =>
    new RecipientAllResponse(
    Recipient.ReceiverId,
    Recipient.EmailId);
}

