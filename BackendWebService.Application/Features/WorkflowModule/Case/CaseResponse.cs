using Application.Profiles;
using Domain;
using Domain.Enums;

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
List<CaseActionResponse> CaseActions): IConvertibleFromEntity<Case, CaseResponse>
{
public static CaseResponse FromEntity(Case Case) =>
new CaseResponse(
Case.ActionIndex,
Case.WorkflowId,
Case.Workflow.ToEntity(),
Case.StatusId,
Case.CompanySupplierId,
Case.CompanySupplier.ToEntity(),
Case.UserId,
Case.User.ToEntity(),
Case.CaseActions.Select(CaseActionResponse.FromEntity).ToList());
}