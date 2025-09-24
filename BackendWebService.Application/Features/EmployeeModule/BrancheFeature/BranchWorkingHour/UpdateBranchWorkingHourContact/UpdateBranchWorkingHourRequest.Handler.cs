using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateBranchWorkingHourRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateBranchWorkingHourRequest, int>
{
    public IResponse<int> Handle(UpdateBranchWorkingHourRequest request)
    {
        throw new NotImplementedException();
    }
}