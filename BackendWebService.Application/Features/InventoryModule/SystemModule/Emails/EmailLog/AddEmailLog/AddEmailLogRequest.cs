using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddEmailLogRequest(
string Subject,
string Body,
DateTime SentAt,
int SenderId,
AddUserRequest Sender) : IConvertibleToEntity<EmailLog>, IRequest<int>
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