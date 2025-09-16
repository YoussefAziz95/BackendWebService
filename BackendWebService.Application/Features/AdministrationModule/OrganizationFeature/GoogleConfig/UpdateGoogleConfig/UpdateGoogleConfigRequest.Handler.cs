using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateGoogleConfigRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateGoogleConfigRequest, int>
{
    public IResponse<int> Handle(UpdateGoogleConfigRequest request)
    {
        throw new NotImplementedException();
    }
}