using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record AddCaseRequest(
int ActionIndex,
int WorkflowId,
AddWorkflowRequest Workflow,
int StatusId,
int? CompanySupplierId,
AddConsumerAccountRequest? CompanySupplier,
int? UserId,
AddUserRequest? User,
List<AddCaseActionRequest>CaseActions):IConvertibleToEntity<Case>
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
User= User.ToEntity(),
CaseActions= CaseActions.Select(x => x.ToEntity()).ToList()
};
}