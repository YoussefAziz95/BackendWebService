using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class BranchWorkingHourResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<BranchWorkingHourRequest, BranchWorkingHourResponse>
{

    public IResponse<BranchWorkingHourResponse> Handle(BranchWorkingHourRequest request)
    {
        var entity = unitOfWork.GenericRepository<BranchWorkingHour>().Get();

        var result = BranchWorkingHourResponse.FromEntity(entity);

        return Success(result);
    }
}