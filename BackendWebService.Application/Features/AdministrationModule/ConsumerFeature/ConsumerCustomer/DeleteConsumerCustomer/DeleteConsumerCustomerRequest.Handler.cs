using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
internal class DeleteConsumerCustomerRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteConsumerCustomerRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteConsumerCustomerRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<ConsumerCustomer>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("ConsumerCustomer not found");
        try
        {
            unitOfWork.GenericRepository<ConsumerCustomer>().Delete(entity);
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
            Message = "ConsumerCustomer deleted successfully"
        };

        return result;
    }
}

