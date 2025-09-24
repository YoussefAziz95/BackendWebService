using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Features;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features; 
internal class DeleteTransactionRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteTransactionRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteTransactionRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<Transaction>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("Transaction not found");
        try
        {
            unitOfWork.GenericRepository<Transaction>().Delete(entity);
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

