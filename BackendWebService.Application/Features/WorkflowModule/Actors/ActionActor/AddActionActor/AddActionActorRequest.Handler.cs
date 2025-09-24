using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddActionActorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddActionActorRequest, int>
{
    public IResponse<int> Handle(AddActionActorRequest request)
    {
        throw new NotImplementedException();
    }
}