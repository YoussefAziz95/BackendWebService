using Application.Profiles;

namespace Application.Features;
public record EmailLogResponse(
string Subject,
string Body,
DateTime SentAt,
int SenderId,
UserResponse Sender) : IConvertibleFromEntity<EmailLog, EmailLogResponse>
{
    public static EmailLogResponse FromEntity(EmailLog EmailLog) =>
    new EmailLogResponse(
    EmailLog.Subject,
    EmailLog.Body,
    EmailLog.SentAt,
    EmailLog.SenderId,
    UserResponse.FromEntity(EmailLog.Sender));
}