using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UpdateClientRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateClientRequest, int>
{
    public IResponse<int> Handle(UpdateClientRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = request.ToEntity();
        try
        {
            unitOfWork.GenericRepository<Client>().Update(entity);
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