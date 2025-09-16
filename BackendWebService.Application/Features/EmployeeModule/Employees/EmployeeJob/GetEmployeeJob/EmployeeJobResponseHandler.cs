using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class EmployeeJobResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmployeeJobRequest, EmployeeJobResponse>
{
 
    public IResponse<EmployeeJobResponse> Handle(EmployeeJobRequest request)
    {
        var entity = unitOfWork.GenericRepository<EmployeeJob>().Get();

        var result = EmployeeJobResponse.FromEntity(entity);

        return Success(result);
    }
}