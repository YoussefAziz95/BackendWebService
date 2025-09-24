using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateBranchEmployeeRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateBranchEmployeeRequest, int>
{
    public IResponse<int> Handle(UpdateBranchEmployeeRequest request)
    {
        throw new NotImplementedException();
    }
}