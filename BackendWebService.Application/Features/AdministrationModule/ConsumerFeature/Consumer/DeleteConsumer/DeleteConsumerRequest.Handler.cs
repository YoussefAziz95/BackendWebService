using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
internal class DeleteConsumerRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteConsumerRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteConsumerRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var company = await unitOfWork.GenericRepository<Consumer>().GetByIdAsync(request.Id);
        if (company == null)
            return NotFound<string>("Consumer not found");
        try
        {
            unitOfWork.GenericRepository<Consumer>().Delete(company);
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
            Message = "Consumer deleted successfully"
        };

        return result;
    }
}

