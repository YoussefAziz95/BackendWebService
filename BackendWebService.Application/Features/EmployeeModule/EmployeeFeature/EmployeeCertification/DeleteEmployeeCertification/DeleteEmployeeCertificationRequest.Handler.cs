

using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
internal class DeleteEmployeeCertificationRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteEmployeeCertificationRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteEmployeeCertificationRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<EmployeeCertification>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("EmployeeCertification not found");
        try
        {
            unitOfWork.GenericRepository<EmployeeCertification>().Delete(entity);
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

