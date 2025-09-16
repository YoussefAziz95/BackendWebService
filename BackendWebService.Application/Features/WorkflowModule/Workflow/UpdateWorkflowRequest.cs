using Application.Profiles;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record UpdateWorkflowRequest(
string? Name,
string? Description,
int UserId,
UpdateUserRequest? User,
int CompanyId,
UpdateCompanyRequest? Company,
List<UpdateWorkflowCycleRequest> WorkflowCycles):IConvertibleToEntity<Workflow>
{
public Workflow ToEntity() => new Workflow
{
Name = Name,
Description = Description,
UserId = UserId,
User= User.ToEntity(),
CompanyId = CompanyId,
Company= Company.ToEntity(),
WorkflowCycles = WorkflowCycles.Select(x => x.ToEntity()).ToList()
};
}