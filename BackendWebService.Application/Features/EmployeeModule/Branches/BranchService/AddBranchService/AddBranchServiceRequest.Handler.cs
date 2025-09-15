using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddBranchServiceRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddBranchServiceRequest, int>
{
    public IResponse<int> Handle(AddBranchServiceRequest request)
    {
        throw new NotImplementedException();
    }
}