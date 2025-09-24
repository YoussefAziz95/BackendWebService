using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddActorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddActorRequest, int>
{
    public IResponse<int> Handle(AddActorRequest request)
    {
        throw new NotImplementedException();
    }
}