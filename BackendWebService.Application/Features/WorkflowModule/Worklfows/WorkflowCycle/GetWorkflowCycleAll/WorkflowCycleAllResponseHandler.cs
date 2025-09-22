using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class WorkflowCycleAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<WorkflowCycleAllRequest, List<WorkflowCycleAllResponse>>
{
    public IResponse<List<WorkflowCycleAllResponse>> Handle(WorkflowCycleAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<WorkflowCycle>().GetAll();

        var result = entity.Select(WorkflowCycleAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

