using Domain;

namespace Application.Features;
public record EmailResponse(
string Subject,
string Body,
DateTime SentAt,
int SenderId,
User Sender);