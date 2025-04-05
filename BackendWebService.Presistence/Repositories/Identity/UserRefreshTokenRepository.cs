using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Persistence.Repositories;

internal class UserRefreshTokenRepository : IUserRefreshTokenRepository
{
    private readonly ApplicationDbContext _context;
    public UserRefreshTokenRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<int> CreateToken(int userId)
    {
        var token = new UserRefreshToken { IsValid = true, UserId = userId };
        await _context.AddAsync(token);
        return token.Id;
    }

    public async Task<UserRefreshToken> GetTokenWithInvalidation(int id)
    {
        var token = await _context.UserRefreshTokens.Where(t => t.IsValid && t.Id.Equals(id)).FirstOrDefaultAsync();

        return token;
    }

    public async Task<User> GetUserByRefreshToken(int tokenId)
    {
        var userId = await _context.UserRefreshTokens.AsNoTracking().Where(c => c.Id.Equals(tokenId))
            .Select(c => c.UserId).FirstOrDefaultAsync();
        var user = await _context.Users.AsNoTracking().Where(c => c.Id.Equals(userId))
            .Include(c => c.UserRoles).ThenInclude(c => c.Role).FirstOrDefaultAsync();
        return user;
    }

    public Task RemoveUserOldTokens(int userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}