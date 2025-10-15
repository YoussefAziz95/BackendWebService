using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class EmployeeResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<EmployeeResponse>
{

    public IResponse<EmployeeResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Employee>().GetById(id);

        var result = EmployeeResponse.FromEntity(entity);

        return Success(result);
    }
}