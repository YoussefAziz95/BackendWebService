using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class BranchServiceAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<BranchServiceAllRequest, List<BranchServiceAllResponse>>
{
    public IResponse<List<BranchServiceAllResponse>> Handle(BranchServiceAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<BranchService>().GetAll();

        var result = entity.Select(BranchServiceAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

