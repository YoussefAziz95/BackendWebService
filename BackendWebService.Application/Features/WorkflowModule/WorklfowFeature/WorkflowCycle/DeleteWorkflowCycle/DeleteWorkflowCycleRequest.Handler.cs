using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain.Enums;

namespace Application.Features;
public class DeleteWorkflowCycleRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteWorkflowCycleRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteWorkflowCycleRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<WorkflowCycle>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("WorkflowCycle not found");
        try
        {
            unitOfWork.GenericRepository<WorkflowCycle>().Delete(entity);
            unitOfWork.CommitAsync();
            await unitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            unitOfWork.RollbackAsync();
        }

        var result = new Response<string>
        {
            Data = "Deleted",
            Succeeded = true,
            StatusCode = ApiResultStatusCode.Success,
            Message = "Company deleted successfully"
        };

        return result;
    }
}

