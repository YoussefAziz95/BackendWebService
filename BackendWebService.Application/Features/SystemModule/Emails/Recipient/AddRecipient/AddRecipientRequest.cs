using Application.Contracts.Features;
using Application.Profiles;

namespace Application.Features;

public record AddRecipientRequest(
int ReceiverId,
int EmailId,
AddActorRequest Reciver,
AddEmailLogRequest Email) : IConvertibleToEntity<Recipient>, IRequest<int>
{
    public Recipient ToEntity() => new Recipient
    {
        ReceiverId = ReceiverId,
        EmailId = EmailId,
        Reciver = Reciver.ToEntity(),
        Email = Email.ToEntity()
    };
}