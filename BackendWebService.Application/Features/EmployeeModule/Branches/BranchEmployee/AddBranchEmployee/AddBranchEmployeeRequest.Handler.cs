using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddBranchEmployeeRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddBranchEmployeeRequest, int>
{
    public IResponse<int> Handle(AddBranchEmployeeRequest request)
    {
        throw new NotImplementedException();
    }
}