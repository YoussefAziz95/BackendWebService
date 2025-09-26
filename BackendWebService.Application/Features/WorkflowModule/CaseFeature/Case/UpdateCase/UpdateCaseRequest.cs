using Application.Contracts.Features;
using Application.Profiles;
namespace Application.Features;
public record UpdateCaseRequest(
int ActionIndex,
int WorkflowId,
UpdateWorkflowRequest Workflow,
int StatusId,
int? CompanySupplierId,
UpdateConsumerAccountRequest? CompanySupplier,
int? UserId,
UpdateUserRequest? User,
List<UpdateCaseActionRequest> CaseActions) : IConvertibleToEntity<Case>, IRequest<int>
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