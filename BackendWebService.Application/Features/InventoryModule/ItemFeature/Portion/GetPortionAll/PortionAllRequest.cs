using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PortionAllRequest(
int Quantity,
int StorageUnitId,
int PortionTypeId,
SizeEnum Size,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<PortionAllResponse>>
{
    public IValidator<PortionAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PortionAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

