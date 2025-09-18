using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateActorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateActorRequest, int>
{
    public IResponse<int> Handle(UpdateActorRequest request)
    {
        throw new NotImplementedException();
    }
}