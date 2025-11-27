using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ServiceResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<ServiceResponse>
{

    public IResponse<ServiceResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Service>().GetById(id);

        var result = ServiceResponse.FromEntity(entity);

        return Success(result);
    }
}