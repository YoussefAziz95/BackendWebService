

using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain.Enums;

namespace Application.Features;
public class DeleteSupplierDocumentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteSupplierDocumentRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteSupplierDocumentRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<SupplierDocument>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("SupplierDocument not found");
        try
        {
            unitOfWork.GenericRepository<SupplierDocument>().Delete(entity);
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

