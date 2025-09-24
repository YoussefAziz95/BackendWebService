using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Features;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features; 
internal class DeleteActionActorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteActionActorRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteActionActorRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<ActionActor>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("ActionActor not found");
        try
        {
            unitOfWork.GenericRepository<ActionActor>().Delete(entity);
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

