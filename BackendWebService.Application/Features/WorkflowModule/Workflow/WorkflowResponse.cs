using Application.Profiles;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record WorkflowResponse(
string? Name,
string? Description,
int UserId,
UserResponse? User,
int CompanyId,
CompanyResponse? Company,
List<WorkflowCycleResponse> WorkflowCycles): IConvertibleFromEntity<Workflow, WorkflowResponse>
{
public static WorkflowResponse FromEntity(Workflow Workflow) =>
new WorkflowAResponse(
Workflow.Name,
Workflow.Description,
Workflow.UserId,
Workflow.User.ToEntity(),
Workflow.CompanyId,
Workflow.Company.ToEntity(),
Workflow.WorkflowCycles.Select(WorkflowCycleResponse.FromEntity).ToList()
);
}