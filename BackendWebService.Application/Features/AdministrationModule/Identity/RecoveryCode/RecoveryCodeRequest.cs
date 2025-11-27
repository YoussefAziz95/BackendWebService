using Application.Contracts.Features;

namespace Application.Features;
public record RecoveryCodeRequest(string RecoveryCode) : IRequest<int>;