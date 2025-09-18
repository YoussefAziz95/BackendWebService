using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserRefreshTokenRequest(
int UserId,
DateTime CreatedAt,
bool IsValid,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IRequest<UserRefreshTokenResponse>
{
public IValidator<UserRefreshTokenRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserRefreshTokenRequest> validator)
{
throw new NotImplementedException();
}
}

