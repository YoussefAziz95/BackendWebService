using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class BranchWorkingHourResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<BranchWorkingHourResponse>
{

    public IResponse<BranchWorkingHourResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<BranchWorkingHour>().GetById(id);

        var result = BranchWorkingHourResponse.FromEntity(entity);

        return Success(result);
    }
}