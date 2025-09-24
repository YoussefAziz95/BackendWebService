using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class WorkflowCycleResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<WorkflowResponse>
{

    public IResponse<WorkflowResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Workflow>().Get();

        var result = WorkflowResponse.FromEntity(entity);

        return Success(result);
    }
}