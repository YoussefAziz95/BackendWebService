

using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
public class DeleteCustomerPaymentMethodRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteCustomerPaymentMethodRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteCustomerPaymentMethodRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<CustomerPaymentMethod>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("CustomerPaymentMethod not found");
        try
        {
            unitOfWork.GenericRepository<CustomerPaymentMethod>().Delete(entity);
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

