using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class UserClaimResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserClaimRequest, UserClaimResponse>
{
 
    public IResponse<UserClaimResponse> Handle(UserClaimRequest request)
    {
        var entity = unitOfWork.GenericRepository<UserClaim>().Get();

        var result = UserClaimResponse.FromEntity(entity);

        return Success(result);
    }
}