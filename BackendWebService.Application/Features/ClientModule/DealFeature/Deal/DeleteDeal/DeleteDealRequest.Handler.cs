

using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
public class DeleteDealRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteDealRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteDealRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<Deal>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("Deal not found");
        try
        {
            unitOfWork.GenericRepository<Deal>().Delete(entity);
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

