using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record UpdateCaseRequest(
int ActionIndex,
int WorkflowId,
UpdateWorkflowRequest Workflow,
int StatusId,
int? CompanySupplierId,
UpdateConsumerAccountRequest?CompanySupplier,
int? UserId,
UpdateUserRequest? User,
List<UpdateCaseActionRequest> CaseActions):IConvertibleToEntity<Case>
{
public Case ToEntity() => new Case
{
ActionIndex = ActionIndex,
WorkflowId = WorkflowId,
Workflow = Workflow.ToEntity(),
StatusId = StatusId,
CompanySupplierId = CompanySupplierId,
CompanySupplier = CompanySupplier.ToEntity(),
UserId = UserId,
User = User.ToEntity(),
CaseActions = CaseActions.Select(x => x.ToEntity()).ToList()
};
}