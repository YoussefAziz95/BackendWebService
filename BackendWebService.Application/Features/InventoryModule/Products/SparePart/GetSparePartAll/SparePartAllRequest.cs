using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record SparePartAllRequest(
int PartId,
int? SpareId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<SparePartAllResponse>>
{
    public IValidator<SparePartAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<SparePartAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

