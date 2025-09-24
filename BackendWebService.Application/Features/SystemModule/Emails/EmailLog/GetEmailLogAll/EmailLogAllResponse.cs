using Application.Profiles;

namespace Application.Features;
public record EmailLogAllResponse(
string Subject,
string Body,
DateTime SentAt,
int SenderId) : IConvertibleFromEntity<EmailLog, EmailLogAllResponse>
{
    public static EmailLogAllResponse FromEntity(EmailLog EmailLog) =>
    new EmailLogAllResponse(
    EmailLog.Subject,
    EmailLog.Body,
    EmailLog.SentAt,
    EmailLog.SenderId);
}

