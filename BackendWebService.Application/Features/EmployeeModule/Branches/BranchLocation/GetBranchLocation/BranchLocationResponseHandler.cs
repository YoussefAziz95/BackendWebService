using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class BranchLocationResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<BranchLocationRequest, BranchLocationResponse>
{
 
    public IResponse<BranchLocationResponse> Handle(BranchLocationRequest request)
    {
        var entity = unitOfWork.GenericRepository<BranchLocation>().Get();

        var result = BranchLocationResponse.FromEntity(entity);

        return Success(result);
    }
}