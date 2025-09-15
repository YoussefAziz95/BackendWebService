using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddBranchContactRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddBranchContactRequest, int>
{
    public IResponse<int> Handle(AddBranchContactRequest request)
    {
        throw new NotImplementedException();
    }
}