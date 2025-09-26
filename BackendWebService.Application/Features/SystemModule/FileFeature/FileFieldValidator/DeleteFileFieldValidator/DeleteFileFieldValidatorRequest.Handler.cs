using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain.Enums;

namespace Application.Features;
internal class DeleteFileFieldValidatorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteFileFieldValidatorRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteFileFieldValidatorRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<FileFieldValidator>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("FileFieldValidator not found");
        try
        {
            unitOfWork.GenericRepository<FileFieldValidator>().Delete(entity);
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

