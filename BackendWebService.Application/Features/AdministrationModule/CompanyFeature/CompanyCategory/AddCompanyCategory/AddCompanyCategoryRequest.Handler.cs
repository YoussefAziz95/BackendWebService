using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class AddCompanyCategoryRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddCompanyCategoryRequest, int>
{
    public IResponse<int> Handle(AddCompanyCategoryRequest request)
    {
        unitOfWork.BeginTransactionAsync();

        var entity = request.ToEntity();

        try
        {
            unitOfWork.GenericRepository<CompanyCategory>().Add(entity);
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