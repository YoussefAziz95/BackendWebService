using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class EmployeeAccountResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmployeeAccountRequest, EmployeeAccountResponse>
{
 
    public IResponse<EmployeeAccountResponse> Handle(EmployeeAccountRequest request)
    {
        var entity = unitOfWork.GenericRepository<EmployeeAccount>().Get();

        var result = EmployeeAccountResponse.FromEntity(entity);

        return Success(result);
    }
}