using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class AddCompanyRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCompanyRequest, int>
{
    public IResponse<int> Handle(AddCompanyRequest request)
    {
        unitOfWork.BeginTransactionAsync();

        var entity = request.ToEntity();

        try
        {
            unitOfWork.GenericRepository<Company>().Add(entity);
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