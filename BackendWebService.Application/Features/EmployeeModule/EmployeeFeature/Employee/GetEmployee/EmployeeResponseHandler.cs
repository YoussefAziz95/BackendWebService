using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class EmployeeResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmployeeRequest, EmployeeResponse>
{

    public IResponse<EmployeeResponse> Handle(EmployeeRequest request)
    {
        var entity = unitOfWork.GenericRepository<Employee>().Get();

        var result = EmployeeResponse.FromEntity(entity);

        return Success(result);
    }
}