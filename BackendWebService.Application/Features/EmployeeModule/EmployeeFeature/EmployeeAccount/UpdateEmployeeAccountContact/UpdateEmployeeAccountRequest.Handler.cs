using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateEmployeeAccountRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateEmployeeAccountRequest, int>
{
    public IResponse<int> Handle(UpdateEmployeeAccountRequest request)
    {
        unitOfWork.BeginTransactionAsync();
        var entity = request.ToEntity();
        try
        {
            unitOfWork.GenericRepository<EmployeeAccount>().Update(entity);
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