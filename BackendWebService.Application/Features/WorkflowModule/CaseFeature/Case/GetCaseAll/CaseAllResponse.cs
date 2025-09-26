using Application.Profiles;

namespace Application.Features;
public record CaseAllResponse(
int ActionIndex,
int WorkflowId,
int StatusId,
int? CompanySupplierId,
int? UserId) : IConvertibleFromEntity<Case, CaseAllResponse>
{
    public static CaseAllResponse FromEntity(Case Case) =>
    new CaseAllResponse(
    Case.ActionIndex,
    Case.WorkflowId,
    Case.StatusId,
    Case.CompanySupplierId,
    Case.UserId);
}
