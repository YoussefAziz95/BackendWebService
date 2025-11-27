using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class CriteriaAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<CriteriaAllRequest, List<CriteriaAllResponse>>
{
    public IResponse<List<CriteriaAllResponse>> Handle(CriteriaAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Criteria>().GetAll();

        var result = entity.Select(CriteriaAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

