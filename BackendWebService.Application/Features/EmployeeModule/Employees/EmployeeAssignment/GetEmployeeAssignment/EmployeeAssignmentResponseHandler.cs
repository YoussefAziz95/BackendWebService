using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class EmployeeAssignmentResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmployeeAssignmentRequest, EmployeeAssignmentResponse>
{
 
    public IResponse<EmployeeAssignmentResponse> Handle(EmployeeAssignmentRequest request)
    {
        var entity = unitOfWork.GenericRepository<EmployeeAssignment>().Get();

        var result = EmployeeAssignmentResponse.FromEntity(entity);

        return Success(result);
    }
}