using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record CategoryAllRequest(
string Name,
int? ParentId,
int? FileId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<CategoryAllResponse>>
{
    public IValidator<CategoryAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<CategoryAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

