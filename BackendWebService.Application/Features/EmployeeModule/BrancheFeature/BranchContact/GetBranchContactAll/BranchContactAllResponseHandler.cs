using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class BranchContactAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<BranchContactAllRequest, List<BranchContactAllResponse>>
{

    public IResponse<List<BranchContactAllResponse>> Handle(BranchContactAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<BranchContact>().GetAll();

        var result = entity.Select(BranchContactAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

