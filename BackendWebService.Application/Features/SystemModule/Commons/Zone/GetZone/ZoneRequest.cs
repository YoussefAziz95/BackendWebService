using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ZoneRequest(
string Name,
string? Description,
int? ParentZoneId) : IRequest<ZoneResponse>
{
    public IValidator<ZoneRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ZoneRequest> validator)
    {
        throw new NotImplementedException();
    }
}

