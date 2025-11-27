using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
public class DeleteConsumerAccountRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteConsumerAccountRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteConsumerAccountRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<ConsumerAccount>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("ConsumerAccount not found");
        try
        {
            unitOfWork.GenericRepository<ConsumerAccount>().Delete(entity);
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
            Message = "ConsumerAccount deleted successfully"
        };

        return result;
    }
}

