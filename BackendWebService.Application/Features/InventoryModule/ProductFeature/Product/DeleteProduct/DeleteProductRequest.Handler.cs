using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Features;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features; 
internal class DeleteProductRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteProductRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteProductRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<Product>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("Product not found");
        try
        {
            unitOfWork.GenericRepository<Product>().Delete(entity);
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

