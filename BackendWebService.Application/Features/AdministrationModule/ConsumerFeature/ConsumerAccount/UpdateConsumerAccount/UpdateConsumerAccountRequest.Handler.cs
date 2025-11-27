using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UpdateConsumerAccountRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateConsumerAccountRequest, int>
{
    public IResponse<int> Handle(UpdateConsumerAccountRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = request.ToEntity();
        try
        {
            unitOfWork.GenericRepository<ConsumerAccount>().Update(entity);
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