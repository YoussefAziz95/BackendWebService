using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record ActionActorRequest(
string Name,
string? Description,
StatusEnum StatusId,
ActionEnum ActionType,
DateTime CreatedAt,
DateTime? UpdatedAt,
int? UserId,
int? TargetEntityId,
TableNameEnum? TableName) : IRequest<ActionActorResponse>
{
    public IValidator<ActionActorRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<ActionActorRequest> validator)
    {
        throw new NotImplementedException();
    }
}

