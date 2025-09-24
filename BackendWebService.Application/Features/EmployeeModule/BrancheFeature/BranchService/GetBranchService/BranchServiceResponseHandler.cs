using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class BranchServiceResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<BranchServiceRequest, BranchServiceResponse>
{

    public IResponse<BranchServiceResponse> Handle(BranchServiceRequest request)
    {
        var entity = unitOfWork.GenericRepository<BranchService>().Get();

        var result = BranchServiceResponse.FromEntity(entity);

        return Success(result);
    }
}