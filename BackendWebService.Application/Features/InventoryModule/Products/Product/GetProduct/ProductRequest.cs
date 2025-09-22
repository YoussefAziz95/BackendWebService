using Application.Contracts.Features;
using Domain;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ProductRequest(
string Number,
string Name,
string Description,
string Code,
string PartNumber,
string Manufacturer,
int? FileId) : IRequest<ProductResponse>
{
public IValidator<ProductRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ProductRequest> validator)
{
throw new NotImplementedException();
}
}

