using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PortionRequest(
int Quantity,
int StorageUnitId,
int PortionTypeId,
SizeEnum Size) : IRequest<PortionResponse>
{
public IValidator<PortionRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PortionRequest> validator)
{
throw new NotImplementedException();
}
}

