using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class ActionObjectResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<ActionObjectRequest, ActionObjectResponse>
{

    public IResponse<ActionObjectResponse> Handle(ActionObjectRequest request)
    {
        var entity = unitOfWork.GenericRepository<ActionObject>().Get();

        var result = ActionObjectResponse.FromEntity(entity);

        return Success(result);
    }
}