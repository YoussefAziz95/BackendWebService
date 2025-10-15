

using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
public class DeleteBranchEmployeeRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteBranchEmployeeRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteBranchEmployeeRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<BranchEmployee>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("BranchEmployee not found");
        try
        {
            unitOfWork.GenericRepository<BranchEmployee>().Delete(entity);
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

