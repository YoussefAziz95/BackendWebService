using Application.Profiles;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record WorkflowResponse(
string? Name,
string? Description,
int? UserId,
UserResponse? User,
int? CompanyId,
CompanyResponse? Company,
List<WorkflowCycleResponse> WorkflowCycles): IConvertibleFromEntity<Workflow, WorkflowResponse>
{
public static WorkflowResponse FromEntity(Workflow Workflow) =>
new WorkflowResponse(
Workflow.Name,
Workflow.Description,
Workflow.UserId,
UserResponse.FromEntity(Workflow.User),
Workflow.CompanyId,
CompanyResponse.FromEntity(Workflow.Company),
Workflow.WorkflowCycles.Select(WorkflowCycleResponse.FromEntity).ToList()
);
}