using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class RoleClaimResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<RoleClaimResponse>
{
 
    public IResponse<RoleClaimResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<RoleClaim>().Get();

        var result = RoleClaimResponse.FromEntity(entity);

        return Success(result);
    }
}