

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteMicrosoftConfigRequest(int Id, string Password = null) : IRequest<string>;
