using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserTokenRequest(
DateTime GeneratedTime,
int Id,
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IRequest<UserTokenResponse>
{
public IValidator<UserTokenRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserTokenRequest> validator)
{
throw new NotImplementedException();
}
}

