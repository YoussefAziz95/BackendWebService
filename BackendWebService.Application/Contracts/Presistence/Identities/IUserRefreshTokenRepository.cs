using Domain;

namespace BackendWebService.Application.Contracts.Persistence;

public interface IUserRefreshTokenRepository
{
    Task<int> CreateToken(int userId);
    Task<UserRefreshToken> GetTokenWithInvalidation(int id);
    Task<User> GetUserByRefreshToken(int tokenId);
    Task RemoveUserOldTokens(int userId, CancellationToken cancellationToken);
}