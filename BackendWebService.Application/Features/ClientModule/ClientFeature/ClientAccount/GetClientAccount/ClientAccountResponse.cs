using Application.Contracts.Features;
using Application.Profiles;

namespace Application.Features;
public record ClientAccountResponse(
int CustomerId,
ClientResponse Customer,
string? Email,
string PasswordHash,
bool IsSocialLogin,
string? SocialProvider,
string? SocialProviderId,
bool TwoFactorEnabled,
bool LockoutEnabled,
DateTimeOffset? LockoutEnd,
int AccessFailedCount,
string AccountStatus,
string? AccountStatusReason,
DateTime CreatedDate,
DateTime? UpdatedDate) : IConvertibleFromEntity<ClientAccount, ClientAccountResponse>, IRequest<int>
{
    public static ClientAccountResponse FromEntity(ClientAccount ClientAccount) =>
    new ClientAccountResponse(
    ClientAccount.CustomerId,
    ClientResponse.FromEntity(ClientAccount.Customer),
    ClientAccount.Email,
    ClientAccount.PasswordHash,
    ClientAccount.IsSocialLogin,
    ClientAccount.SocialProvider,
    ClientAccount.SocialProviderId,
    ClientAccount.TwoFactorEnabled,
    ClientAccount.LockoutEnabled,
    ClientAccount.LockoutEnd,
    ClientAccount.AccessFailedCount,
    ClientAccount.AccountStatus,
    ClientAccount.AccountStatusReason,
    ClientAccount.CreatedDate,
    ClientAccount.UpdatedDate);
}
