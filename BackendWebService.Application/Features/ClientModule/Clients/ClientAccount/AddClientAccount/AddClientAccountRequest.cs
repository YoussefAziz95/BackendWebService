using Application.Contracts.Features;
using Application.Profiles;

namespace Application.Features;

public record AddClientAccountRequest(
int CustomerId,
AddClientRequest Customer,
string? Email,
string PasswordHash,
bool IsSocialLogin,
string? SocialProvider,
string? SocialProviderId,
bool TwoFactorEnabled,
bool LockoutEnabled,
DateTime? LockoutEnd,
int AccessFailedCount,
string AccountStatus,
string? AccountStatusReason,
DateTime CreatedDate,
DateTime? UpdatedDate) : IConvertibleToEntity<ClientAccount>, IRequest<int>
{
    public ClientAccount ToEntity() => new ClientAccount
    {
        CustomerId = CustomerId,
        Customer = Customer.ToEntity(),
        Email = Email,
        IsSocialLogin = IsSocialLogin,
        SocialProvider = SocialProvider,
        SocialProviderId = SocialProviderId,
        TwoFactorEnabled = TwoFactorEnabled,
        LockoutEnabled = LockoutEnabled,
        LockoutEnd = LockoutEnd,
        AccessFailedCount = AccessFailedCount,
        AccountStatus = AccountStatus,
        AccountStatusReason = AccountStatusReason,
        CreatedDate = CreatedDate,
        UpdatedDate = UpdatedDate
    };
}

