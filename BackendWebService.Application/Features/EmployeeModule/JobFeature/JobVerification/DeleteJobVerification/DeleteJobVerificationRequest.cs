

using Application.Contracts.Features;

namespace Application.Features;

public record DeleteJobVerificationRequest(int Id, string Password = null) : IRequest<string>;
