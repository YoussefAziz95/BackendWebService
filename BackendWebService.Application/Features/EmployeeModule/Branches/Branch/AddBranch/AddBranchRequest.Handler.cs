using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddBranchRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddBranchRequest, int>
{
    public IResponse<int> Handle(AddBranchRequest request)
    {
        throw new NotImplementedException();
    }
}