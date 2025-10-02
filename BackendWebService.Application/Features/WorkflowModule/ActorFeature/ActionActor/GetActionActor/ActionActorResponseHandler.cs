using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ActionActorResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<ActionActorResponse>
{

    public IResponse<ActionActorResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<ActionActor>().GetById(id);

        var result = ActionActorResponse.FromEntity(entity);

        return Success(result);
    }
}