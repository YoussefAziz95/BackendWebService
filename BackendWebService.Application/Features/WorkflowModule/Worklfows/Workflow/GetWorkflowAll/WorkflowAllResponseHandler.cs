using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class WorkflowAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<WorkflowAllRequest, List<WorkflowAllResponse>>
{
    public IResponse<List<WorkflowAllResponse>> Handle(WorkflowAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Workflow>().GetAll();

        var result = entity.Select(WorkflowAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

