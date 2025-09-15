using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class EmployeeAssignmentAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmployeeAssignmentAllRequest, List<EmployeeAssignmentAllResponse>>
{
    public IResponse<List<EmployeeAssignmentAllResponse>> Handle(EmployeeAssignmentAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<EmployeeAssignment>().GetAll();

        var result = entity.Select(EmployeeAssignmentAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

