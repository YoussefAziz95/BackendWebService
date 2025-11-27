using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class CaseActionAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<CaseActionAllRequest, List<CaseActionAllResponse>>
{
    public IResponse<List<CaseActionAllResponse>> Handle(CaseActionAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<CaseAction>().GetAll();

        var result = entity.Select(CaseActionAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

