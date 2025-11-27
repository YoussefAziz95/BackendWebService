using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
public class DeleteConsumerRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteConsumerRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteConsumerRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<Consumer>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("Consumer not found");
        try
        {
            unitOfWork.GenericRepository<Consumer>().Delete(entity);
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
            Message = "Consumer deleted successfully"
        };

        return result;
    }
}

