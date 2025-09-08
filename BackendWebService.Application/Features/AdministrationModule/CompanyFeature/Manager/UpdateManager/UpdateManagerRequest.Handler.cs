using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateManagerRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateManagerRequest, int>
{
    public IResponse<int> Handle(UpdateManagerRequest request)
    {
        throw new NotImplementedException();
    }
}