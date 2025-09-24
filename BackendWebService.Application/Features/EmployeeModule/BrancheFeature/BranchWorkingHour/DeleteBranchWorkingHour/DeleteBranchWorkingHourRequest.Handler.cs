

using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
internal class DeleteBranchWorkingHourRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteBranchWorkingHourRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteBranchWorkingHourRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<BranchWorkingHour>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("BranchWorkingHour not found");
        try
        {
            unitOfWork.GenericRepository<BranchWorkingHour>().Delete(entity);
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

