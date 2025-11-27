using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class EmployeeAssignmentResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<EmployeeAssignmentResponse>
{

    public IResponse<EmployeeAssignmentResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<EmployeeAssignment>().GetById(id);

        var result = EmployeeAssignmentResponse.FromEntity(entity);

        return Success(result);
    }
}