using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;


public class AddStorageUnitRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddStorageUnitRequest, int>
{
    public IResponse<int> Handle(AddStorageUnitRequest request)
    {
        throw new NotImplementedException();
    }
}