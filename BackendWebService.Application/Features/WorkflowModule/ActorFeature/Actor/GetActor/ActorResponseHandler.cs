using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ActorResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<ActorResponse>
{

    public IResponse<ActorResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Actor>().GetById(id);

        var result = ActorResponse.FromEntity(entity);

        return Success(result);
    }
}