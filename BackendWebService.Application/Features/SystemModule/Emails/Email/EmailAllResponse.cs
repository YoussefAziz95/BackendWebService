using Domain;
using Domain.Enums;

namespace Application.Features;
public record EmailAllResponse(
string Subject,
string Body,
DateTime SentAt,
int SenderId,
User Sender);

