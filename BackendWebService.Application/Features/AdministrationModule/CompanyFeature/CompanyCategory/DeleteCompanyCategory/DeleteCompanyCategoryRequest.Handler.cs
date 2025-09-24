using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
internal class DeleteCompanyCategoryRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteCompanyCategoryRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteCompanyCategoryRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var company = await unitOfWork.GenericRepository<CompanyCategory>().GetByIdAsync(request.Id);
        if (company == null)
            return NotFound<string>("Company not found");
        try
        {
            unitOfWork.GenericRepository<CompanyCategory>().Delete(company);
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

