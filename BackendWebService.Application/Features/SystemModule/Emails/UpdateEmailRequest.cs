using Domain;

namespace Application.Features;
public record UpdateEmailRequest(
string Subject,
string Body,
DateTime SentAt,
int SenderId,
User Sender);