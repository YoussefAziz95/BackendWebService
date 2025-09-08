using Application.Profiles;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace Application.Features;
public record AddWorkflowRequest(
string? Name,
string? Description,
int UserId,
AddUserRequest? User,
int CompanyId,
AddCompanyCategoryRequest? Company,
List<AddWorkflowCycleRequest> WorkflowCycles):IConvertibleToEntity<Workflow>
{
public Workflow ToEntity() => new Workflow
{
Name = Name,
Description = Description, 
UserId = UserId,
User= User.ToEntity(),
CompanyId = CompanyId,
Company= Company.ToEntity(),
WorkflowCycles = WorkflowCycles.Select(x => x.ToEntity()).ToList()};
}