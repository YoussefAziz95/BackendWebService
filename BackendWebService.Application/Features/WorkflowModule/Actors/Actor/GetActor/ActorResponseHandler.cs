using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class ActorResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ActorRequest, ActorResponse>
{
 
    public IResponse<ActorResponse> Handle(ActorRequest request)
    {
        var entity = unitOfWork.GenericRepository<Actor>().Get();

        var result = ActorResponse.FromEntity(entity);

        return Success(result);
    }
}