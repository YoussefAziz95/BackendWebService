using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record InventoryRequest(
string Name,
int? CategoryId) : IRequest<InventoryResponse>
{
public IValidator<InventoryRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<InventoryRequest> validator)
{
throw new NotImplementedException();
}
}

