using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateActionActorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateActionActorRequest, int>
{
    public IResponse<int> Handle(UpdateActionActorRequest request)
    {
        throw new NotImplementedException();
    }
}