using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class GroupAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<GroupAllRequest, List<GroupAllResponse>>
{
    public IResponse<List<GroupAllResponse>> Handle(GroupAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<Group>().GetAll();

        var result = entity.Select(GroupAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

