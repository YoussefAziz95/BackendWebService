namespace Application.Features;
public record AddEmailRequest(
string Subject,
string Body,
DateTime SentAt,
int SenderId);