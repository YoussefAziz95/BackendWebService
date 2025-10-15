

using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
public class DeleteMicrosoftConfigRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteMicrosoftConfigRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteMicrosoftConfigRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<MicrosoftConfig>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("MicrosoftConfig not found");
        try
        {
            unitOfWork.GenericRepository<MicrosoftConfig>().Delete(entity);
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

