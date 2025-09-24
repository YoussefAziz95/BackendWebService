using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ClientAccountAllRequest(
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
string? AccountStatusReason,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ClientAccountAllResponse>>
{
    public IValidator<ClientAccountAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ClientAccountAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

