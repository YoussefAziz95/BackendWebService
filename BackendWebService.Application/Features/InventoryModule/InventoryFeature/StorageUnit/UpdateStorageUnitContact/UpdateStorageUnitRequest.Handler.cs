using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateStorageUnitRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateStorageUnitRequest, int>
{
    public IResponse<int> Handle(UpdateStorageUnitRequest request)
    {
        throw new NotImplementedException();
    }
}