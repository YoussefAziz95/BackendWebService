using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record UserGroupAllRequest(
int GroupId,
int UserId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<UserGroupAllResponse>>
{
    public IValidator<UserGroupAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<UserGroupAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

