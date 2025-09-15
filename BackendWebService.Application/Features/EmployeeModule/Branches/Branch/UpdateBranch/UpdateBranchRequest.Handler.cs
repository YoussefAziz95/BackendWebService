using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateBranchRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateBranchRequest, int>
{
    public IResponse<int> Handle(UpdateBranchRequest request)
    {
        throw new NotImplementedException();
    }
}