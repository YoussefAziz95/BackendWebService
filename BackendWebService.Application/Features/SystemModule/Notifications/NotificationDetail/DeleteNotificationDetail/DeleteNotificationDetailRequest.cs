using Application.Contracts.Features;

namespace Application.Features; 
public record DeleteNotificationDetailRequest(int Id, string Password = null) : IRequest<string>;
