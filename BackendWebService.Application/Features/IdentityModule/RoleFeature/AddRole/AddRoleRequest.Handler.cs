using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddRoleRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddRoleRequest, int>
{
    public IResponse<int> Handle(AddRoleRequest request)
    {
        unitOfWork.BeginTransactionAsync();

        var entity = request.ToEntity();

        try
        {
            unitOfWork.GenericRepository<Role>().Add(entity);
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