using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record SpareRequest(
bool? IsAvailable,
int? RequiredAmount,
int? AvailableAmount,
int? ProductId) : IRequest<SpareResponse>
{
    public IValidator<SpareRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<SpareRequest> validator)
    {
        throw new NotImplementedException();
    }
}

