using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;


namespace Application.Features;


public class AddWorkflowCycleRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddWorkflowCycleRequest, int>
{
    public IResponse<int> Handle(AddWorkflowCycleRequest request)
    {
        unitOfWork.BeginTransactionAsync();

        var entity = request.ToEntity();

        try
        {
            unitOfWork.GenericRepository<WorkflowCycle>().Add(entity);
            var result = unitOfWork.Save();
        }
        catch (Exception ex)
        {
            unitOfWork.RollbackAsync();
            return BadRequest<int>(message: ex.Message);

        }

        unitOfWork.CommitAsync();
        return Success(entity.Id);
    }
}