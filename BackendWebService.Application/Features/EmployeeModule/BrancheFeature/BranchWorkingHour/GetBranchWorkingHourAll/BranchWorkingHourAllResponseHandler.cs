using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class BranchWorkingHourAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<BranchWorkingHourAllRequest, List<BranchWorkingHourAllResponse>>
{
    public IResponse<List<BranchWorkingHourAllResponse>> Handle(BranchWorkingHourAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<BranchWorkingHour>().GetAll();

        var result = entity.Select(BranchWorkingHourAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

