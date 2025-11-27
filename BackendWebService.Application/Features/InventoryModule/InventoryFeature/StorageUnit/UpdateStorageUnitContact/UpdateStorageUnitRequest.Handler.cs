using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateStorageUnitRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateStorageUnitRequest, int>
{
    public IResponse<int> Handle(UpdateStorageUnitRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = request.ToEntity();
        try
        {
            unitOfWork.GenericRepository<StorageUnit>().Update(entity);
            var result = unitOfWork.Save();
        }
        catch (Exception ex)
        {
            unitOfWork.RollbackAsync();
            return BadRequest<int>(message: ex.Message);

        }

        unitOfWork.CommitAsync();
        return Success(entity.Id);
    }
}