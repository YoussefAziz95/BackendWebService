using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Features;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features; 
internal class DeleteFileTypeRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteFileTypeRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteFileTypeRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<FileType>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("FileType not found");
        try
        {
            unitOfWork.GenericRepository<FileType>().Delete(entity);
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

