using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UpdateMicrosoftConfigRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateMicrosoftConfigRequest, int>
{
    public IResponse<int> Handle(UpdateMicrosoftConfigRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = request.ToEntity();
        try
        {
            unitOfWork.GenericRepository<MicrosoftConfig>().Update(entity);
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