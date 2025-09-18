using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ProductAllRequest(
string Number,
string Name,
string Description,
string Code,
string PartNumber,
string Manufacturer,
int? FileId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ProductAllResponse>>
{
    public IValidator<ProductAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ProductAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

