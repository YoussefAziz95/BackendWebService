using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class BranchEmployeeAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<BranchEmployeeAllRequest, List<BranchLocationAllResponse>>
{

    public IResponse<List<BranchLocationAllResponse>> Handle(BranchEmployeeAllRequest request)
    {
        //var entity = unitOfWork.GenericRepository<BranchEmployee>().GetAll();

        //var result = entity.Select(BranchLocationAllResponse.FromEntity).ToList();

        //return Success(result);
        throw new NotImplementedException();
    }
}

