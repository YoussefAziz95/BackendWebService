using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class PortionAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<PortionAllRequest, List<PortionAllResponse>>
{
    public IResponse<List<PortionAllResponse>> Handle(PortionAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Portion>().GetAll();

        var result = entity.Select(PortionAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

