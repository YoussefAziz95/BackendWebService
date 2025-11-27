using Application.Contracts.Features;

namespace Application.Features;
public record DeleteEmailLogRequest(int Id, string Password = null) : IRequest<string>;
