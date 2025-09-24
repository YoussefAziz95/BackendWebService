using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class CaseAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<CaseAllRequest, List<CaseAllResponse>>
{
    public IResponse<List<CaseAllResponse>> Handle(CaseAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Case>().GetAll();

        var result = entity.Select(CaseAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

