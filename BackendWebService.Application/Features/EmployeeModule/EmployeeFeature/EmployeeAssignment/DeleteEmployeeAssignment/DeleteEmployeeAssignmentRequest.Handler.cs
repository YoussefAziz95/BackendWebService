

using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Domain.Enums;

namespace Application.Features;
internal class DeleteEmployeeAssignmentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandlerAsync<DeleteEmployeeAssignmentRequest, string>
{
    public async Task<IResponse<string>> HandleAsync(DeleteEmployeeAssignmentRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = await unitOfWork.GenericRepository<EmployeeAssignment>().GetByIdAsync(request.Id);
        if (entity == null)
            return NotFound<string>("EmployeeAssignment not found");
        try
        {
            unitOfWork.GenericRepository<EmployeeAssignment>().Delete(entity);
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

