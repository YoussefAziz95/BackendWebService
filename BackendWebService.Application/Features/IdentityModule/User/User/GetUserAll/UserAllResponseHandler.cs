using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class UserAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UserAllRequest, List<UserAllResponse>>
{
    public IResponse<List<UserAllResponse>> Handle(UserAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<User>().GetAll();

        var result = entity.Select(UserAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

