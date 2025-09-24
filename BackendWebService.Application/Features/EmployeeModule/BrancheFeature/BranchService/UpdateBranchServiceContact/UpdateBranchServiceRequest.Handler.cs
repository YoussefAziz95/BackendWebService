using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateBranchServiceRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateBranchServiceRequest, int>
{
    public IResponse<int> Handle(UpdateBranchServiceRequest request)
    {
        throw new NotImplementedException();
    }
}