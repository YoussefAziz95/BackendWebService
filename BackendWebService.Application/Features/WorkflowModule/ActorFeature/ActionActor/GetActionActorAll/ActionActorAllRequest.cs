using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ActionActorAllRequest(
string Name,
string? Description,
StatusEnum StatusId,
ActionEnum ActionType,
DateTime CreatedAt,
DateTime? UpdatedAt,
int? UserId,
int? TargetEntityId,
TableNameEnum? TableName,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<ActionActorAllResponse>>
{
    public IValidator<ActionActorAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ActionActorAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

