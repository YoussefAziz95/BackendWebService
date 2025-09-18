using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PartRequest(
string Name,
string Description,
string Code,
string Image,
string PartNumber,
string Manufacturer,
int ProductId) : IRequest<PartResponse>
{
public IValidator<PartRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PartRequest> validator)
{
throw new NotImplementedException();
}
}

