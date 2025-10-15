using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class StorageUnitResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<StorageUnitResponse>
{

    public IResponse<StorageUnitResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<StorageUnit>().GetById(id);

        var result = StorageUnitResponse.FromEntity(entity);

        return Success(result);
    }
}