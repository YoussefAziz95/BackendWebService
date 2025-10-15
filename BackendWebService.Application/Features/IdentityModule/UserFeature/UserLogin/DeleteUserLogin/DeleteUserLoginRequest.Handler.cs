using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
public class DeleteUserLoginRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteUserLoginRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteUserLoginRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<UserLogin>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("UserLog not found");
        try
        {
            unitOfWork.GenericRepository<UserLogin>().Delete(entity);
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

