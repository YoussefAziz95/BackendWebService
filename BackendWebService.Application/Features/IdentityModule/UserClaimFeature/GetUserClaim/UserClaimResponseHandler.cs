using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UserClaimResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<UserClaimResponse>
{

    public IResponse<UserClaimResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<UserClaim>().GetById(id);

        var result = UserClaimResponse.FromEntity(entity);

        return Success(result);
    }
}