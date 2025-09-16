using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class EmployeeCertificationResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<EmployeeCertificationRequest, EmployeeCertificationResponse>
{
 
    public IResponse<EmployeeCertificationResponse> Handle(EmployeeCertificationRequest request)
    {
        var entity = unitOfWork.GenericRepository<EmployeeCertification>().Get();

        var result = EmployeeCertificationResponse.FromEntity(entity);

        return Success(result);
    }
}