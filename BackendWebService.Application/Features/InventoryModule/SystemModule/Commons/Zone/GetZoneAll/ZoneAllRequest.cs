using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ZoneAllRequest(
string Name,
string? Description,
int? ParentZoneId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ZoneAllResponse>>
{
    public IValidator<ZoneAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ZoneAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

