using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddItemRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddItemRequest, int>
{
    public IResponse<int> Handle(AddItemRequest request)
    {
        unitOfWork.BeginTransactionAsync();

        var entity = request.ToEntity();

        try
        {
            unitOfWork.GenericRepository<Item>().Add(entity);
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