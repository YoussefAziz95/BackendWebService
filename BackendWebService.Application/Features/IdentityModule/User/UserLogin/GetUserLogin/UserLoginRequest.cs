using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserLoginRequest(
int? OrganizationId,
DateTime LoggedOn,
bool? IsActive,
bool? IsDeleted,
bool? IsSystem,
DateTime? CreatedDate,
string? CreatedBy,
DateTime? UpdatedDate,
string? UpdatedBy) : IRequest<UserLoginResponse>
{
public IValidator<UserLoginRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserLoginRequest> validator)
{
throw new NotImplementedException();
}
}

