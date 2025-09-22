using Application.Contracts.Features;
using Application.Profiles;
using Domain;
namespace Application.Features;
public record UpdateWorkflowRequest(
string? Name,
string? Description,
int UserId,
UpdateUserRequest? User,
int CompanyId,
UpdateCompanyRequest? Company,
List<UpdateWorkflowCycleRequest> WorkflowCycles) : IConvertibleToEntity<Workflow>,IRequest<int>
{
    public Workflow ToEntity() => new Workflow
    {
        Name = Name,
        Description = Description,
        UserId = UserId,
        User = User.ToEntity(),
        CompanyId = CompanyId,
        Company = Company.ToEntity(),
        WorkflowCycles = WorkflowCycles.Select(x => x.ToEntity()).ToList()
    };
}