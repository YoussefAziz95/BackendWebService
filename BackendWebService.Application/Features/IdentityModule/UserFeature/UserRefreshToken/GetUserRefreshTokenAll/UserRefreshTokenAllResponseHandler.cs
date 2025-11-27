using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class UserRefreshTokenAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserRefreshTokenAllRequest, List<UserRefreshTokenAllResponse>>
{
    public IResponse<List<UserRefreshTokenAllResponse>> Handle(UserRefreshTokenAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<UserRefreshToken>().GetAll();

        var result = entity.Select(UserRefreshTokenAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

