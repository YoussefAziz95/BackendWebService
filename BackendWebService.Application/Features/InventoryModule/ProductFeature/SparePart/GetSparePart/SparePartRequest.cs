using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record SparePartRequest(
int PartId,
int? SpareId) : IRequest<SparePartResponse>
{
    public IValidator<SparePartRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<SparePartRequest> validator)
    {
        throw new NotImplementedException();
    }
}

