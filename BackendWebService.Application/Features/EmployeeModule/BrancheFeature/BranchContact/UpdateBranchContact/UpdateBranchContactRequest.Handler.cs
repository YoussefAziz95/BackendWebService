using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateBranchContactRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateBranchContactRequest, int>
{
    public IResponse<int> Handle(UpdateBranchContactRequest request)
    {
        throw new NotImplementedException();
    }
}