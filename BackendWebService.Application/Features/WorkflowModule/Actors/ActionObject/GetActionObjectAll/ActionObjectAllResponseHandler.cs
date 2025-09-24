using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class ActionObjectAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ActionObjectAllRequest, List<ActionObjectAllResponse>>
{
    public IResponse<List<ActionObjectAllResponse>> Handle(ActionObjectAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<ActionObject>().GetAll();

        var result = entity.Select(ActionObjectAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

