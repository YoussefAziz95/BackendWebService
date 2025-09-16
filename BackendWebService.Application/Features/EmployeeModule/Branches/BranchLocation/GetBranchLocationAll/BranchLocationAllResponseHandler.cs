using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class BranchLocationAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<BranchLocationAllRequest, List<BranchLocationAllResponse>>
{
    public IResponse<List<BranchLocationAllResponse>> Handle(BranchLocationAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<BranchLocation>().GetAll();

        var result = entity.Select(BranchLocationAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

