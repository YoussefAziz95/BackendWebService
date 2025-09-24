using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features; 
internal class StorageUnitResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<StorageUnitRequest, StorageUnitResponse>
{

    public IResponse<StorageUnitResponse> Handle(StorageUnitRequest request)
    {
        var entity = unitOfWork.GenericRepository<StorageUnit>().Get();

        var result = StorageUnitResponse.FromEntity(entity);

        return Success(result);
    }
}