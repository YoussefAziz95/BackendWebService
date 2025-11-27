using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class EmployeeAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmployeeAllRequest, List<EmployeeAllResponse>>
{
    public IResponse<List<EmployeeAllResponse>> Handle(EmployeeAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Employee>().GetAll();

        var result = entity.Select(EmployeeAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

