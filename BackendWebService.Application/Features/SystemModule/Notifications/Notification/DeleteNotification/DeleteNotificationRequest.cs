using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteNotificationRequest(int Id, string Password = null) : IRequest<string>;
