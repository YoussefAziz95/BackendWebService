using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record BranchContactAllRequest(
int BranchId,
string Type,
string Value,
ContactEnum ContactType,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<BranchContactAllResponse>>
{
    public IValidator<BranchContactAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<BranchContactAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

