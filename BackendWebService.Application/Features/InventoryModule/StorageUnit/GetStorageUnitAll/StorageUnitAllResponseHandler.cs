using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class StorageUnitAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<StorageUnitAllRequest, List<StorageUnitAllResponse>>
{
    public IResponse<List<StorageUnitAllResponse>> Handle(StorageUnitAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<StorageUnit>().GetAll();

        var result = entity.Select(StorageUnitAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

