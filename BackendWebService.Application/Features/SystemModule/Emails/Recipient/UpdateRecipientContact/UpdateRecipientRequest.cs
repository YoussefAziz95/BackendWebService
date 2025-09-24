using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateRecipientRequest(
int ReceiverId,
int EmailId,
UpdateActorRequest Reciver,
UpdateEmailLogRequest Email) : IConvertibleToEntity<Recipient>, IRequest<int>
{
    public Recipient ToEntity() => new Recipient
    {
        ReceiverId = ReceiverId,
        EmailId = EmailId,
        Reciver = Reciver.ToEntity(),
        Email = Email.ToEntity()
    };
}