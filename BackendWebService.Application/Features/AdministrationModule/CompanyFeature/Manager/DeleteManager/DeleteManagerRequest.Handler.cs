using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
public class DeleteManagerRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteManagerRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteManagerRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<Manager>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("Manager not found");
        try
        {
            unitOfWork.GenericRepository<Manager>().Delete(entity);
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
            Message = "Manager deleted successfully"
        };

        return result;
    }
}

