using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class ServiceResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ServiceRequest, ServiceResponse>
{
 
    public IResponse<ServiceResponse> Handle(ServiceRequest request)
    {
        var entity = unitOfWork.GenericRepository<Service>().Get();

        var result = ServiceResponse.FromEntity(entity);

        return Success(result);
    }
}