using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ActorAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ActorAllRequest, List<ActorAllResponse>>
{
    public IResponse<List<ActorAllResponse>> Handle(ActorAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Actor>().GetAll();

        var result = entity.Select(ActorAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

