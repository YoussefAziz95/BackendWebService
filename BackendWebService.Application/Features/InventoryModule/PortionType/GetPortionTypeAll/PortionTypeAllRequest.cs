using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PortionTypeAllRequest(
string Name,
string? Description,
string? UnitOfMeasure,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<PortionTypeAllResponse>>
{
    public IValidator<PortionTypeAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PortionTypeAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

