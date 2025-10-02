using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class EmployeeServiceAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmployeeServiceAllRequest, List<EmployeeServiceAllResponse>>
{
    public IResponse<List<EmployeeServiceAllResponse>> Handle(EmployeeServiceAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<EmployeeService>().GetAll();

        var result = entity.Select(EmployeeServiceAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

