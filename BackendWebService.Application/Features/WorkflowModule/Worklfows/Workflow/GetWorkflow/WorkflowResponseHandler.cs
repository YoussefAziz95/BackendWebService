using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class WorkflowResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<WorkflowResponse>
{
 
    public IResponse<WorkflowResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Workflow>().Get();

        var result = WorkflowResponse.FromEntity(entity);

        return Success(result);
    }
}