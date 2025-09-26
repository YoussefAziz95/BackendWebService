using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class UserLoginAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserLoginAllRequest, List<UserLoginAllResponse>>
{
    public IResponse<List<UserLoginAllResponse>> Handle(UserLoginAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<UserLogin>().GetAll();

        var result = entity.Select(UserLoginAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

