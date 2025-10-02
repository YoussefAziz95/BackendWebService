using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ActionActorAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ActionActorAllRequest, List<ActionActorAllResponse>>
{
    public IResponse<List<ActionActorAllResponse>> Handle(ActionActorAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<ActionActor>().GetAll();

        var result = entity.Select(ActionActorAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

