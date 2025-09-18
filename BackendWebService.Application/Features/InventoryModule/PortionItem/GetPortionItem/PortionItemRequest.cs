using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PortionItemRequest(
int PortionId,
 int ItemId) : IRequest<PortionItemResponse>
{
public IValidator<PortionItemRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PortionItemRequest> validator)
{
throw new NotImplementedException();
}
}

