using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class ActionActorResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ActionActorRequest, ActionActorResponse>
{

    public IResponse<ActionActorResponse> Handle(ActionActorRequest request)
    {
        var entity = unitOfWork.GenericRepository<ActionActor>().Get();

        var result = ActionActorResponse.FromEntity(entity);

        return Success(result);
    }
}