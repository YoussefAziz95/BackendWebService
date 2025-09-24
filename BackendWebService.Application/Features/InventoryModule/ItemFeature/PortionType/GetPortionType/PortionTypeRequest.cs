using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PortionTypeRequest(
string Name,
string? Description,
string? UnitOfMeasure) : IRequest<PortionTypeResponse>
{
    public IValidator<PortionTypeRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PortionTypeRequest> validator)
    {
        throw new NotImplementedException();
    }
}

