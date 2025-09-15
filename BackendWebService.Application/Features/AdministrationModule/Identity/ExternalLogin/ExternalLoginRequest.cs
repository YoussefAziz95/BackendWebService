using Application.Contracts.Features;

namespace Application.Features;
public record ExternalLoginRequest(
    string Provider, 
    string ProviderKey) : IRequest<int>;