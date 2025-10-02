using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class PortionTypeAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<PortionTypeAllRequest, List<PortionTypeAllResponse>>
{
    public IResponse<List<PortionTypeAllResponse>> Handle(PortionTypeAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<PortionType>().GetAll();

        var result = entity.Select(PortionTypeAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

