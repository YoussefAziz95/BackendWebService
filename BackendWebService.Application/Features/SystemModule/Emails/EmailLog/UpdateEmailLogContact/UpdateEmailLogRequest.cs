using Application.Contracts.Features;
using Application.Profiles;
namespace Application.Features;
public record UpdateEmailLogRequest(
string Subject,
string Body,
DateTime SentAt,
int SenderId,
UpdateUserRequest Sender) : IConvertibleToEntity<EmailLog>, IRequest<int>
{
    public EmailLog ToEntity() => new EmailLog
    {
        Subject = Subject,
        Body = Body,
        SentAt = SentAt,
        SenderId = SenderId,
        Sender = Sender.ToEntity()
    };
}