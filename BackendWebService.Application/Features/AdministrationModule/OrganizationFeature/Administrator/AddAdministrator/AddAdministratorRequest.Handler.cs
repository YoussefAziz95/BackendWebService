using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddAdministratorRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddAdministratorRequest, int>
{

    public IResponse<int> Handle(AddAdministratorRequest request)
    {
        unitOfWork.BeginTransactionAsync();

        var entity = request.ToEntity();

        try
        {
            unitOfWork.GenericRepository<Administrator>().Add(entity);
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