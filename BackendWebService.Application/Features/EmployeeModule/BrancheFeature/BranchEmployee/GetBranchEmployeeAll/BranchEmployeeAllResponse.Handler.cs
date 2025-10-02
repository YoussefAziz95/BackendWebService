using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class BranchEmployeeAllReponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<BranchEmployeeAllRequest, List<BranchEmployeeAllResponse>>
{

    public IResponse<List<BranchEmployeeAllResponse>> Handle(BranchEmployeeAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<BranchEmployee>().GetAll();

        var result = entity.Select(BranchEmployeeAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

