using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UpdateSpareRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateSpareRequest, int>
{
    public IResponse<int> Handle(UpdateSpareRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = request.ToEntity();
        try
        {
            unitOfWork.GenericRepository<Spare>().Update(entity);
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