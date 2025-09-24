using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddBranchLocationRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddBranchLocationRequest, int>
{
    public IResponse<int> Handle(AddBranchLocationRequest request)
    {
        throw new NotImplementedException();
    }
}