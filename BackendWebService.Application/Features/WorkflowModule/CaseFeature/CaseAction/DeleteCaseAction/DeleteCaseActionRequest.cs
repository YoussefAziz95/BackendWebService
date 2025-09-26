using Application.Contracts.Features;

namespace Application.Features;
public record DeleteCaseActionRequest(int Id, string Password = null) : IRequest<string>;
