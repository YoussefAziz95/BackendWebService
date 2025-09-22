using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserClaimRequest(
int? OrganizationId,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IRequest<UserClaimResponse>
{
public IValidator<UserClaimRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserClaimRequest> validator)
{
throw new NotImplementedException();
}
}

