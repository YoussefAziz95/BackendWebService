using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateBranchLocationRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateBranchLocationRequest, int>
{
    public IResponse<int> Handle(UpdateBranchLocationRequest request)
    {
        throw new NotImplementedException();
    }
}