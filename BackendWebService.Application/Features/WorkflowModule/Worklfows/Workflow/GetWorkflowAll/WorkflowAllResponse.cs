using Application.Profiles;
using Domain;
using Domain.Enums;

namespace Application.Features;
public record WorkflowAllResponse(
string? Name,
string? Description,
int? UserId,
int? CompanyId) : IConvertibleFromEntity<Workflow, WorkflowAllResponse>
{
    public static WorkflowAllResponse FromEntity(Workflow Workflow) =>
    new WorkflowAllResponse(
    Workflow.Name,
    Workflow.Description,
    Workflow.UserId,
    Workflow.CompanyId);
}