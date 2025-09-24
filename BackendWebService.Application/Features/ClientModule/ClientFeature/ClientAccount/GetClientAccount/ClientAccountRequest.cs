using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ClientAccountRequest(
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
string? AccountStatusReason) : IRequest<ClientAccountResponse>
{
    public IValidator<ClientAccountRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ClientAccountRequest> validator)
    {
        throw new NotImplementedException();
    }
}

