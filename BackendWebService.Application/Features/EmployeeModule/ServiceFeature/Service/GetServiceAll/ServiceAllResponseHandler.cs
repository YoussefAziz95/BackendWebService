using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ServiceAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ServiceAllRequest, List<ServiceAllResponse>>
{
    public IResponse<List<ServiceAllResponse>> Handle(ServiceAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Service>().GetAll();

        var result = entity.Select(ServiceAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

