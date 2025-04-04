using Domain;

namespace Application.Contracts.Services;

public interface IJwtProvider
{
    Task<string> Generate(User user);
}
