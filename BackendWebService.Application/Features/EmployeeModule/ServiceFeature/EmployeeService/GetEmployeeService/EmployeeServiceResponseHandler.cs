using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class EmployeeServiceResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<EmployeeServiceResponse>
{

    public IResponse<EmployeeServiceResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<EmployeeService>().GetById(id);

        var result = EmployeeServiceResponse.FromEntity(entity);

        return Success(result);
    }
}