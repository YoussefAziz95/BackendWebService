using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddUserRefreshTokenRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddUserRefreshTokenRequest, Guid>
{
    public IResponse<Guid> Handle(AddUserRefreshTokenRequest request)
    {
        unitOfWork.BeginTransactionAsync();

        var entity = request.ToEntity();

        try
        {
            unitOfWork.GenericRepository<UserRefreshToken>().Add(entity);
            var result = unitOfWork.Save();
        }
        catch (Exception ex)
        {
            unitOfWork.RollbackAsync();
            return BadRequest<Guid>(message: ex.Message);

        }

        unitOfWork.CommitAsync();
        return Success(entity.Id);
    }
}