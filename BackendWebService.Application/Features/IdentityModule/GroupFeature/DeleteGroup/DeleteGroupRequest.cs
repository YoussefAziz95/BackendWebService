using Application.Contracts.Features;

namespace Application.Features;
public record DeleteGroupRequest(int Id, string Password = null) : IRequest<string>;
