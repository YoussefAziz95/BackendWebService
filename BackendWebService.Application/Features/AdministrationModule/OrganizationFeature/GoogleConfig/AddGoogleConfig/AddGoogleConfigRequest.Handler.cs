using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddGoogleConfigRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddGoogleConfigRequest, int>
{
    public IResponse<int> Handle(AddGoogleConfigRequest request)
    {
        throw new NotImplementedException();
    }
}