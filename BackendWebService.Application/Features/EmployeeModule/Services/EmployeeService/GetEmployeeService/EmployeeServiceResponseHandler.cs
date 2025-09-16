using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class EmployeeServiceResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmployeeServiceRequest, EmployeeServiceResponse>
{
 
    public IResponse<EmployeeServiceResponse> Handle(EmployeeServiceRequest request)
    {
        var entity = unitOfWork.GenericRepository<EmployeeService>().Get();

        var result = EmployeeServiceResponse.FromEntity(entity);

        return Success(result);
    }
}