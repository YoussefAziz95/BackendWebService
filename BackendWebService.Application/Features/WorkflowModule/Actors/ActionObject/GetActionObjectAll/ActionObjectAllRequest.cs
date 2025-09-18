using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ActionObjectAllRequest(
int ActionId,
string ActionType,
int ObjectId,
string ObjectType,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ActionObjectAllResponse>>
{
    public IValidator<ActionObjectAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ActionObjectAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

