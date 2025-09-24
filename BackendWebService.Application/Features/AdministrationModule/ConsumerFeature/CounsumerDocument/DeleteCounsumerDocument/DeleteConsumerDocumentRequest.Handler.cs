using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain.Enums;

namespace Application.Features;
internal class DeleteConsumerDocumentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteConsumerDocumentRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteConsumerDocumentRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var company = await unitOfWork.GenericRepository<ConsumerDocument>().GetByIdAsync(request.Id);
        if (company == null)
            return NotFound<string>("ConsumerDocument not found");
        try
        {
            unitOfWork.GenericRepository<ConsumerDocument>().Delete(company);
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
            Message = "ConsumerDocument deleted successfully"
        };

        return result;
    }
}

