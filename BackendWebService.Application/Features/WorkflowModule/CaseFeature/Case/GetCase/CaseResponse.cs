using Application.Profiles;

namespace Application.Features;
public record CaseResponse(
int ActionIndex,
int WorkflowId,
WorkflowResponse Workflow,
int StatusId,
int? CompanySupplierId,
ConsumerAccountResponse? CompanySupplier,
int? UserId,
UserResponse? User,
List<CaseActionResponse> CaseActions) : IConvertibleFromEntity<Case, CaseResponse>
{
    public static CaseResponse FromEntity(Case Case) =>
    new CaseResponse(
    Case.ActionIndex,
    Case.WorkflowId,
    WorkflowResponse.FromEntity(Case.Workflow),
    Case.StatusId,
    Case.CompanySupplierId,
    ConsumerAccountResponse.FromEntity(Case.CompanySupplier),
    Case.UserId,
    UserResponse.FromEntity(Case.User),
    Case.CaseActions.Select(CaseActionResponse.FromEntity).ToList());
}