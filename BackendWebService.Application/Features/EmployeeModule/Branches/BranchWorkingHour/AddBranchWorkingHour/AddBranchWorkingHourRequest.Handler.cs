using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddBranchWorkingHourRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddBranchWorkingHourRequest, int>
{
    public IResponse<int> Handle(AddBranchWorkingHourRequest request)
    {
        throw new NotImplementedException();
    }
}