using Application.Contracts.Features;
using Application.Profiles;

namespace Application.Features;

public record AddWorkflowRequest(
string? Name,
string? Description,
int UserId,
AddUserRequest? User,
int CompanyId,
AddCompanyRequest? Company,
List<AddWorkflowCycleRequest> WorkflowCycles) : IConvertibleToEntity<Workflow>, IRequest<int>
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