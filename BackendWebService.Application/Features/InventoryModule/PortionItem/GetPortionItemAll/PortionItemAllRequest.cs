using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record PortionItemAllRequest(
int PortionId,
 int PortionItemId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<PortionItemAllResponse>>
{
    public IValidator<PortionItemAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<PortionItemAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

