using Application.Profiles;
using Domain;

namespace Application.Features;
public record AddEmailLogRequest(
string Subject,
string Body,
DateTime SentAt,
int SenderId,
AddUserRequest Sender):IConvertibleToEntity<EmailLog>
{
public EmailLog ToEntity() => new EmailLog
{
Subject = Subject,
Body = Body,
SentAt = SentAt,
SenderId = SenderId,
Sender= Sender.ToEntity()
};
}