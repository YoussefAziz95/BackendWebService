using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class UserTokenAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserTokenAllRequest, List<UserTokenAllResponse>>
{
    public IResponse<List<UserTokenAllResponse>> Handle(UserTokenAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<UserToken>().GetAll();

        var result = entity.Select(UserTokenAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

