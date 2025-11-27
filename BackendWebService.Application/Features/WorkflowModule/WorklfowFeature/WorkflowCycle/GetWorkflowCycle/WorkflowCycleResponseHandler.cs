using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class WorkflowCycleResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<WorkflowCycleResponse>
{

    public IResponse<WorkflowCycleResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<WorkflowCycle>().GetById(id);

        var result = WorkflowCycleResponse.FromEntity(entity);

        return Success(result);
    }
}