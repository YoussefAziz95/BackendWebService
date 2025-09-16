using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;

public record ClientAccountAllResponse(
int CustomerId,
string? Email,
string PasswordHash,
bool IsSocialLogin,
string? SocialProvider,
string? SocialProviderId,
bool TwoFactorEnabled,
bool LockoutEnabled,
int AccessFailedCount,
string AccountStatus,
string? AccountStatusReason) : IConvertibleFromEntity<ClientAccount, ClientAccountAllResponse>
{
    public static ClientAccountAllResponse FromEntity(ClientAccount ClientAccount) =>
    new ClientAccountAllResponse(
    ClientAccount.CustomerId,
    ClientAccount.Email,
    ClientAccount.PasswordHash,
    ClientAccount.IsSocialLogin,
    ClientAccount.SocialProvider,
    ClientAccount.SocialProviderId,
    ClientAccount.TwoFactorEnabled,
    ClientAccount.LockoutEnabled,
    ClientAccount.AccessFailedCount,
    ClientAccount.AccountStatus,
    ClientAccount.AccountStatusReason);
}
