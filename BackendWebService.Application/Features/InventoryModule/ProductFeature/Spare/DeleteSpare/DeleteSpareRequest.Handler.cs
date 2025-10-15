using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
public class DeleteSpareRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteSpareRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteSpareRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<Spare>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("Spare not found");
        try
        {
            unitOfWork.GenericRepository<Spare>().Delete(entity);
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

