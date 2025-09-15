using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record BranchContactRequest(
int BranchId,
string Type,
string Value,
ContactEnum ContactType) : IRequest<BranchContactResponse>
{
public IValidator<BranchContactRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<BranchContactRequest> validator)
{
throw new NotImplementedException();
}
}

