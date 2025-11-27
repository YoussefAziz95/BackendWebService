using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PartAllRequest(
string Name,
string Description,
string Code,
string Image,
string PartNumber,
string Manufacturer,
int ProductId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<PartAllResponse>>
{
    public IValidator<PartAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PartAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

