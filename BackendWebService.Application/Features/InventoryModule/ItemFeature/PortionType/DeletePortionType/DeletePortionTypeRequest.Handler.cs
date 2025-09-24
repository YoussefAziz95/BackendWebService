using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Features;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features; 
internal class DeletePortionTypeRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeletePortionTypeRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeletePortionTypeRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<PortionType>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("PortionType not found");
        try
        {
            unitOfWork.GenericRepository<PortionType>().Delete(entity);
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

