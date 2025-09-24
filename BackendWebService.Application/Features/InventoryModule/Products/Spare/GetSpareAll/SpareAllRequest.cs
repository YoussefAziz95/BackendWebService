using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record SpareAllRequest(
bool? IsAvailable,
int? RequiredAmount,
int? AvailableAmount,
int? ProductId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<SpareAllResponse>>
{
    public IValidator<SpareAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<SpareAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

