using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ServiceAllRequest(
string Name,
string Description,
string Code,
int CategoryId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ServiceAllResponse>>
{
    public IValidator<ServiceAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ServiceAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

