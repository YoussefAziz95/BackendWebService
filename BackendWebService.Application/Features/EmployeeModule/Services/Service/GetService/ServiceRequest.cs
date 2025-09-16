using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ServiceRequest(
string Name,
string Description,
string Code,
int CategoryId) : IRequest<ServiceResponse>
{
public IValidator<ServiceRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ServiceRequest> validator)
{
throw new NotImplementedException();
}
}

