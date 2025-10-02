using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ActionObjectResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<ActionObjectResponse>
{

    public IResponse<ActionObjectResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<ActionObject>().GetById(id);

        var result = ActionObjectResponse.FromEntity(entity);

        return Success(result);
    }
}